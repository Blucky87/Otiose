using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Nez;
using Nez.UI;
using Otiose.svelto;

namespace Core.svelto.components
{
    //based on nez IRenderable
    public interface IRenderableComponent : IComponent
    {
        RectangleF Bounds { get; }

        bool Enabled { get; set; }
        float LayerDepth { get; set; }
        int RenderLayer { get; set; }
        Material Material { get; set; }
        bool IsVisible { get; }
        T GetMaterial<T>() where T : Material;
        bool IsVisibleFromCamera(Camera camera);
        void Render(Graphics graphics, Camera camera);
        void DebugRender(Graphics graphics);
    }

    public interface ICameraComponent : IComponent
    {
        float PositionZ3D { get; set; } //= 2000f;
        float NearClipPlane3D { get; set; } //= 0.0001f;
        float FarClipPlane3D { get; set; } // = 5000f;

        float Rotation { get; set; }
        Vector2 Position { get; set; }

        float RawZoom { get; set; }
        float Zoom { get; set; }
        float MinimumZoom { get; set; }
        float MaximumZoom { get; set; }

        RectangleF Bounds { get; }

        Matrix2D TransformMaxtrix2D { get; }
        Matrix2D InverseTransformMatrix2D { get; }
        Matrix ProjectionMatrix { get; }

        Matrix ProjectionMaxtrix3D { get; }
        Matrix ViewMatrix3D { get; }

        Vector2 Origin { get; set; }

    }

}
