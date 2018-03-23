using System;
using Microsoft.Xna.Framework;
using Nez;

namespace Otiose.Input
{
    public class TwoAxisInputControl : IInputControl
    {
        public float X { get; protected set; }
        public float Y { get; protected set; }

        public OneAxisInputControl Left { get; protected set; }
        public OneAxisInputControl Right { get; protected set; }
        public OneAxisInputControl Up { get; protected set; }
        public OneAxisInputControl Down { get; protected set; }

        public ulong UpdateTick { get; protected set; }

        public float LowerDeadZone = 0.0f;
        public float UpperDeadZone = 1.0f;
        
        float stateThreshold = 0.0f;

        public bool Raw;

        bool thisState;
        bool lastState;
        Vector2 thisValue;
        Vector2 lastValue;

        bool clearInputState;


        public TwoAxisInputControl()
        {
            Left = new OneAxisInputControl();
            Right = new OneAxisInputControl();
            Up = new OneAxisInputControl();
            Down = new OneAxisInputControl();
        }

        public void ClearInputState()
        {
            Left.ClearInputState();
            Right.ClearInputState();
            Up.ClearInputState();
            Down.ClearInputState();

            lastState = false;
            lastValue = Vector2.Zero;
            thisState = false;
            thisValue = Vector2.Zero;

            clearInputState = true;
        }


        // TODO: Is there a better way to handle this? Maybe calculate deltaTime internally.
        public void Filter(TwoAxisInputControl twoAxisInputControl)
        {
            UpdateWithAxes(twoAxisInputControl.X, twoAxisInputControl.Y);
        }


        internal void UpdateWithAxes(float x, float y)
        {
            lastState = thisState;
            lastValue = thisValue;

            thisValue = Raw ? new Vector2(x, y) : Utility.ApplyCircularDeadZone(x, y, LowerDeadZone, UpperDeadZone);

            X = thisValue.X;
            Y = thisValue.Y;

            Left.CommitWithValue(Math.Max(0.0f, -X));
            Right.CommitWithValue(Math.Max(0.0f, X));

            if (InputManager.InvertYAxis)
            {
                Up.CommitWithValue(Math.Max(0.0f, -Y));
                Down.CommitWithValue(Math.Max(0.0f, Y));
            }
            else
            {
                Up.CommitWithValue(Math.Max(0.0f, Y));
                Down.CommitWithValue(Math.Max(0.0f, -Y));
            }

            thisState = Up.State || Down.State || Left.State || Right.State;

            if (clearInputState)
            {
                lastState = thisState;
                lastValue = thisValue;
                clearInputState = false;
                HasChanged = false;
                return;
            }

            if (thisValue != lastValue)
            {
                UpdateTick = Time.frameCount;
                HasChanged = true;
            }
            else
            {
                HasChanged = false;
            }
        }
        
        public float StateThreshold
        {
            set
            {
                stateThreshold = value;
                Left.StateThreshold = value;
                Right.StateThreshold = value;
                Up.StateThreshold = value;
                Down.StateThreshold = value;
            }

            get => stateThreshold;
        }

        public bool State => thisState;

        public bool LastState => lastState;

        public Vector2 Value => thisValue;

        public Vector2 LastValue => lastValue;

        public Vector2 Vector => thisValue;

        public bool HasChanged
        {
            get;
            protected set;
        }

        public bool IsPressed => thisState;

        public bool WasPressed => thisState && !lastState;

        public bool WasReleased => !thisState && lastState;

        public float Angle => Utility.VectorToAngle(thisValue);

        public static implicit operator bool(TwoAxisInputControl instance) => instance.thisState;

        public static implicit operator Vector2(TwoAxisInputControl instance) => instance.thisValue;

        public static implicit operator Vector3(TwoAxisInputControl instance) => new Vector3(instance.thisValue.X, instance.thisValue.Y, 0);
    }
}

