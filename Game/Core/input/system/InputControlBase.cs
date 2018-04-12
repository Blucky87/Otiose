using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nez;

namespace Otiose.Input
{
    public abstract class InputControlBase : IInputControl
    {
        public uint UpdateTick { get; protected set; }

        float sensitivity = 1.0f;
        float lowerDeadZone = 0.0f;
        float upperDeadZone = 1.0f;
        float stateThreshold = 0.0f;

        public float FirstRepeatDelay = 0.8f;
        public float RepeatDelay = 0.1f;

        public bool Raw;

        internal bool Enabled = true;

        uint pendingTick;
        bool pendingCommit;

        float nextRepeatTime;
        float lastPressedTime;
        bool wasRepeated;

        bool clearInputState;

        InputControlState lastState;
        InputControlState nextState;
        InputControlState thisState;


        void PrepareForUpdate()
        {
            uint updateTick = Time.frameCount;
            
            if (updateTick < pendingTick)
            {
                throw new InvalidOperationException("Cannot be updated with an earlier tick.");
            }

            if (pendingCommit && updateTick != pendingTick)
            {
                throw new InvalidOperationException("Cannot be updated for a new tick until pending tick is committed.");
            }

            if (updateTick > pendingTick)
            {
                lastState = thisState;
                nextState.Reset();
                pendingTick = updateTick;
                pendingCommit = true;
            }
            
        }


        public bool UpdateWithState(bool state)
        {
            PrepareForUpdate();

            nextState.Set(state || nextState.State);

            return state;
        }


        public bool UpdateWithValue(float value)
        {
            PrepareForUpdate();

            if (Utility.Abs(value) > Utility.Abs(nextState.RawValue))
            {
                nextState.RawValue = value;

                if (!Raw)
                {
                    value = Utility.ApplyDeadZone(value, lowerDeadZone, upperDeadZone);
                    //					value = Utility.ApplySmoothing( value, lastState.Value, deltaTime, sensitivity );
                }

                nextState.Set(value, stateThreshold);

                return true;
            }

            return false;
        }


        internal bool UpdateWithRawValue(float value)
        {
            PrepareForUpdate();

            if (Utility.Abs(value) > Utility.Abs(nextState.RawValue))
            {
                nextState.RawValue = value;
                nextState.Set(value, stateThreshold);
                return true;
            }

            return false;
        }


        internal void SetValue(float value)
        {
            uint updateTick = Time.frameCount;
                
            if (updateTick > pendingTick)
            {
                lastState = thisState;
                nextState.Reset();
                pendingTick = updateTick;
                pendingCommit = true;
            }

            nextState.RawValue = value;
            nextState.Set(value, StateThreshold);
        }


        public void ClearInputState()
        {
            lastState.Reset();
            thisState.Reset();
            nextState.Reset();
            wasRepeated = false;
            clearInputState = true;
        }


        public void Commit()
        {
            pendingCommit = false;
            //			nextState.Set( Utility.ApplySmoothing( nextState.Value, lastState.Value, Time.deltaTime, sensitivity ), stateThreshold );
            thisState = nextState;

            if (clearInputState)
            {
                // The net result here should be that the entire state will return zero/false 
                // from when ResetState() is called until the next call to Commit(), which is
                // the next update tick, and WasPressed, WasReleased and WasRepeated will then
                // return false during this following tick.
                lastState = nextState;
                UpdateTick = pendingTick;
                clearInputState = false;
                return;
            }

            var lastPressed = lastState.State;
            var thisPressed = thisState.State;

            wasRepeated = false;
            if (lastPressed && !thisPressed) // if was released...
            {
                nextRepeatTime = 0.0f;
            }
            else
            if (thisPressed) // if is pressed...
            {
                if (lastPressed != thisPressed) // if has changed...
                {
                    nextRepeatTime = Time.time + FirstRepeatDelay;
                }
                else
                if (Time.time >= nextRepeatTime)
                {
                    wasRepeated = true;
                    nextRepeatTime = Time.time + RepeatDelay;
                }
            }

            if (thisState != lastState)
            {
                UpdateTick = pendingTick;
            }
        }


        public void CommitWithState(bool state)
        {
            UpdateWithState(state);
            Commit();
        }


        public void CommitWithValue(float value)
        {
            UpdateWithValue(value);
            Commit();
        }


        public bool State => Enabled && thisState.State;


        public bool LastState => Enabled && lastState.State;


        public float Value => Enabled ? thisState.Value : 0.0f;


        public float LastValue => Enabled ? lastState.Value : 0.0f;


        public float RawValue => Enabled ? thisState.RawValue : 0.0f;


        internal float NextRawValue => Enabled ? nextState.RawValue : 0.0f;


        public bool HasChanged => Enabled && thisState != lastState;


        public bool IsPressed => Enabled && thisState.State;


        public bool WasPressed => Enabled && thisState && !lastState;


        public bool WasReleased => Enabled && !thisState && lastState;


        public bool WasRepeated => Enabled && wasRepeated;


        public float Sensitivity
        {
            get => sensitivity;
            set => sensitivity = Mathf.clamp01(value);
        }


        public float LowerDeadZone
        {
            get => lowerDeadZone;
            set => lowerDeadZone = Mathf.clamp01(value);
        }


        public float UpperDeadZone
        {
            get => upperDeadZone;
            set => upperDeadZone = Mathf.clamp01(value);
        }


        public float StateThreshold
        {
            get => stateThreshold;
            set => stateThreshold = Mathf.clamp01(value);
        }


        public static implicit operator bool(InputControlBase instance) => instance.State;

        public static implicit operator float(InputControlBase instance) => instance.Value;
    }
}
