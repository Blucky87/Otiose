using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using Core.svelto.components;
using Microsoft.Xna.Framework;
using Otiose.Input;
using Otiose.Input.Setup;
using Otiose.svelto;

namespace Core.svelto.implementors
{
    class PlayerActionSetComponent : IPlayerActionSet, IImplementor
    {
        public PlayerActionSet Value { get; set; }

        public PlayerActionSetComponent(PlayerActionSet playerActionSet)
        {
            Value = playerActionSet;
        }

    }

    class PlayerTwoAxisActionComponent : IImplementor, 
        IPlayerActionLeftStickComponent, IPlayerActionRightStickComponent
    {
        public PlayerTwoAxisAction Value { get; set; }
    }

    class PlayerActionComponent : IImplementor,
        IPlayerActionOneComponent, IPlayerActionTwoComponent, IPlayerAction
    {
        public PlayerAction Value { get; set; }
    }

    class PlayerActionContextComponent : IPlayerActionContextComponent, IImplementor
    {
        public int Value { get; set; }
    }
}
