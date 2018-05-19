using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Otiose.Input.Setup;
using Otiose.svelto;
using Svelto.ECS;

namespace Core.svelto.components
{
    public interface IPlayerActionSet : IComponent
    {
        PlayerActionSet Value { get; set; }
    }

    public interface IMoveActionComponent : IComponent
    {
        Vector2 Value { get; set; }
    }

    public interface IAimComponent : IComponent
    {
        Vector2 Value { get; set; }
    }

    public interface IActionOne : IComponent
    {
        bool WasPressed { get; }
        bool IsPressed { get; }
        bool WasReleased { get; }
    }

    public interface IActionTwo : IComponent
    {
        bool WasPressed { get; }
        bool IsPressed { get; }
        bool WasReleased { get; }
    }

    public interface IPlayerActionSetContextComponent : IComponent
    {
        int Value { get; set; }
    }

    public static class PlayerActionContext
    {
        public const int UI = 0;
        public const int Roam = 1;
        public const int Cutscene = 2;
    }

    public struct ActionTwoAxisData
    {
        public float X;
        public float Y;
        public EGID EntityId;

        public ActionTwoAxisData(EGID entityId, float x, float y)
        {
            EntityId = entityId;
            X = x;
            Y = y;
        }
    }

    struct ActionButtonData
    {
        public bool IsPressed;
        public bool WasPressed;
        public bool WasReleased;

        public ActionButtonData(bool isPressed, bool wasPressed, bool wasReleased)
        {
            IsPressed = isPressed;
            WasPressed = wasPressed;
            WasReleased = wasReleased;
        }
    }
}
