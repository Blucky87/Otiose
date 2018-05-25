using System;
using System.Collections.Generic;
using System.Text;
using Core.svelto.components;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input.Touch;
using Nez;
using Otiose.svelto;

namespace Core.svelto.implementors
{
    class RenderableImplementors : IRenderableComponent, IImplementor
    {
        public RectangleF Bounds { get; }
        public bool Enabled { get; set; }
        public float LayerDepth { get; set; }
        public int RenderLayer { get; set; }
        public Material Material { get; set; }
        public bool IsVisible { get; }
        public T GetMaterial<T>() where T : Material
        {
            throw new NotImplementedException();
        }

        public bool IsVisibleFromCamera(Camera camera)
        {
            throw new NotImplementedException();
        }

        public void Render(Graphics graphics, Camera camera)
        {
            throw new NotImplementedException();
        }

        public void DebugRender(Graphics graphics)
        {
            throw new NotImplementedException();
        }
    }

    public class CameraImplementor : ICameraComponent, IImplementor
    {
        struct CameraInset
        {
            internal float left;
            internal float right;
            internal float top;
            internal float bottom;
        }

        private bool _areBoundsDirty = true;
        private bool _areMatrixesDirty = true;
        private bool _isProjectionMatrixDirty = true;

        private RectangleF _bounds;
        private CameraInset _inset;
        private Matrix2D _transformMatrix = Matrix2D.identity;
        private Matrix2D _inverseTransformMatrix = Matrix2D.identity;
        private Matrix _projectionMatrix;
        private Vector2 _origin;

        
        private float nearClipPlane3D = 0.0001f;
        private float farClipPlane3D = 5000f;



        private float _zoom;
        private float _minimumZoom = 0.3f;
        private float _maximumZoom = 3f;

        public CameraImplementor()
        {
            PositionZ3D = 2000f;
            NearClipPlane3D = 0.0001f;
            FarClipPlane3D = 5000f;
        }

        public float PositionZ3D { get; set; }
        public float NearClipPlane3D { get; set; }
        public float FarClipPlane3D { get; set; }
        public float Rotation { get; set; }
        public Vector2 Position { get; set; }

        public float RawZoom
        {
            get { return _zoom;}
            set
            {
                if (value != _zoom)
                {
                    _zoom = value;
                    _areBoundsDirty = true;
                }
            }
        }

        public float Zoom
        {
            get
            {
                if (_zoom == 0f)
                {
                    return 1.0f;
                }

                if (_zoom < 1)
                {
                    return Mathf.map(_zoom, _minimumZoom, 1, -1, 0);
                }

                return Mathf.map(_zoom, 1, _maximumZoom, 0, 1);
            }

            set { setZoom(value); }
        }

        public float MaximumZoom
        {
            get { return _maximumZoom; }
            set { setMaximumZoom(value); }
        }

        public float MinimumZoom
        {
            get { return _minimumZoom; }
            set { setMinimumZoom(value); }
        }

        public RectangleF Bounds {
            get
            {
                if (_areMatrixesDirty)
                    updateMatrixes();

                if (_areBoundsDirty)
                {
                    // top-left and bottom-right are needed by either rotated or non-rotated bounds
                    var topLeft = screenToWorldPoint(new Vector2(Nez.Core.graphicsDevice.Viewport.X + _inset.left, Nez.Core.graphicsDevice.Viewport.Y + _inset.top));
                    var bottomRight = screenToWorldPoint(new Vector2(Nez.Core.graphicsDevice.Viewport.X + Nez.Core.graphicsDevice.Viewport.Width - _inset.right, Nez.Core.graphicsDevice.Viewport.Y + Nez.Core.graphicsDevice.Viewport.Height - _inset.bottom));

                    if (Rotation != 0)
                    {
                        // special care for rotated bounds. we need to find our absolute min/max values and create the bounds from that
                        var topRight = screenToWorldPoint(new Vector2(Nez.Core.graphicsDevice.Viewport.X + Nez.Core.graphicsDevice.Viewport.Width - _inset.right, Nez.Core.graphicsDevice.Viewport.Y + _inset.top));
                        var bottomLeft = screenToWorldPoint(new Vector2(Nez.Core.graphicsDevice.Viewport.X + _inset.left, Nez.Core.graphicsDevice.Viewport.Y + Nez.Core.graphicsDevice.Viewport.Height - _inset.bottom));

                        var minX = Mathf.minOf(topLeft.X, bottomRight.X, topRight.X, bottomLeft.X);
                        var maxX = Mathf.maxOf(topLeft.X, bottomRight.X, topRight.X, bottomLeft.X);
                        var minY = Mathf.minOf(topLeft.Y, bottomRight.Y, topRight.Y, bottomLeft.Y);
                        var maxY = Mathf.maxOf(topLeft.Y, bottomRight.Y, topRight.Y, bottomLeft.Y);

                        _bounds.location = new Vector2(minX, minY);
                        _bounds.width = maxX - minX;
                        _bounds.height = maxY - minY;
                    }
                    else
                    {
                        _bounds.location = topLeft;
                        _bounds.width = bottomRight.X - topLeft.X;
                        _bounds.height = bottomRight.Y - topLeft.Y;
                    }

                    _areBoundsDirty = false;
                }

                return _bounds;
            }
        }

        public Matrix2D TransformMaxtrix2D
        {
            get
            {
                if (_areMatrixesDirty)
                    updateMatrixes();
                return _transformMatrix;
            }
        }

        public Matrix2D InverseTransformMatrix2D
        {
            get
            {
                if (_areMatrixesDirty)
                    updateMatrixes();
                return _inverseTransformMatrix;
            }
        }

        public Matrix ProjectionMatrix
        {
            get
            {
                if (_isProjectionMatrixDirty)
                {
                    Matrix.CreateOrthographicOffCenter(0, Nez.Core.graphicsDevice.Viewport.Width, Nez.Core.graphicsDevice.Viewport.Height, 0, 0, -1, out _projectionMatrix);
                    _isProjectionMatrixDirty = false;
                }
                return _projectionMatrix;
            }
        }

        public Matrix ProjectionMaxtrix3D
        {
            get
            {
                var targetHeight = (Nez.Core.graphicsDevice.Viewport.Height / _zoom);
                var fov = (float)Math.Atan(targetHeight / (2f * PositionZ3D)) * 2f;
                return Matrix.CreatePerspectiveFieldOfView(fov, Nez.Core.graphicsDevice.Viewport.AspectRatio, nearClipPlane3D, farClipPlane3D);
            }
        }

        public Matrix ViewProjectionMatrix { get { return TransformMaxtrix2D * ProjectionMatrix; } }

        public Matrix ViewMatrix3D
        {
            get
            {
                // we need to always invert the y-values to match the way Batcher/SpriteBatch does things
                var position3D = new Vector3(Position.X, -Position.Y, PositionZ3D);
                return Matrix.CreateLookAt(position3D, position3D + Vector3.Forward, Vector3.Up);
            }
        }


        public Vector2 Origin
        {
            get { return _origin; }
            set
            {
                if (_origin != value)
                {
                    _origin = value;
                    forceMatrixUpdate();
                }
            }
        }


        public void zoomIn(float deltaZoom)
        {
            Zoom += deltaZoom;
        }

        public void zoomOut(float deltaZoom)
        {
            Zoom -= deltaZoom;
        }

        public CameraImplementor setZoom(float zoom)
        {
            var newZoom = Mathf.clamp(zoom, -1, 1);
            if (newZoom == 0)
                _zoom = 1f;
            else if (newZoom < 0)
                _zoom = Mathf.map(newZoom, -1, 0, _minimumZoom, 1);
            else
                _zoom = Mathf.map(newZoom, 0, 1, 1, _maximumZoom);

            _areMatrixesDirty = true;

            return this;
        }

        public CameraImplementor setMinimumZoom(float minZoom)
        {
            Assert.isTrue(minZoom > 0, "minimumZoom must be greater than zero");

            if (_zoom < minZoom)
                _zoom = MinimumZoom;

            _minimumZoom = minZoom;
            return this;
        }

        public CameraImplementor setMaximumZoom(float maxZoom)
        {
            Assert.isTrue(maxZoom > 0, "MaximumZoom must be greater than zero");

            if (_zoom > maxZoom)
                _zoom = maxZoom;

            _maximumZoom = maxZoom;
            return this;
        }

        public void forceMatrixUpdate()
        {
            _areMatrixesDirty = _areBoundsDirty = true;
        }

        protected virtual void updateMatrixes()
        {
            if (!_areMatrixesDirty)
                return;

            Matrix2D tempMat;
            _transformMatrix = Matrix2D.createTranslation(-Position.X, -Position.Y); // position

            if (_zoom != 1f)
            {
                Matrix2D.createScale(_zoom, _zoom, out tempMat); // scale ->
                Matrix2D.multiply(ref _transformMatrix, ref tempMat, out _transformMatrix);
            }

            if (Rotation != 0f)
            {
                Matrix2D.createRotation(Rotation, out tempMat); // rotation
                Matrix2D.multiply(ref _transformMatrix, ref tempMat, out _transformMatrix);
            }

            Matrix2D.createTranslation((int)_origin.X, (int)_origin.Y, out tempMat); // translate -origin
            Matrix2D.multiply(ref _transformMatrix, ref tempMat, out _transformMatrix);

            // calculate our inverse as well
            Matrix2D.invert(ref _transformMatrix, out _inverseTransformMatrix);

            // whenever the matrix changes the bounds are then invalid
            _areBoundsDirty = true;
            _areMatrixesDirty = false;
        }

        public Vector2 screenToWorldPoint(Point screenPosition)
        {
            return screenToWorldPoint(screenPosition.ToVector2());
        }

        public Vector2 screenToWorldPoint(Vector2 screenPosition)
        {
            updateMatrixes();
            Vector2Ext.transform(ref screenPosition, ref _inverseTransformMatrix, out screenPosition);
            return screenPosition;
        }

        internal void onSceneRenderTargetSizeChanged(int newWidth, int newHeight)
        {
            _isProjectionMatrixDirty = true;
            var oldOrigin = _origin;
            Origin = new Vector2(newWidth / 2f, newHeight / 2f);

            // offset our position to match the new center
            Position += (_origin - oldOrigin);
        }

        public CameraImplementor setInset(float left, float right, float top, float bottom)
        {
            _inset = new CameraInset { left = left, right = right, top = top, bottom = bottom };
            _areBoundsDirty = true;
            return this;
        }

        public Vector2 mouseToWorldPoint()
        {
            return screenToWorldPoint(Input.mousePosition);
        }

        public Vector2 touchToWorldPoint(TouchLocation touch)
        {
            return screenToWorldPoint(touch.scaledPosition());
        }
    }
}
