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

    class PlayerActionComponent : IPlayerAction, IImplementor
    {
        public PlayerAction Value { get; set; }

        public PlayerActionComponent(PlayerAction playerAction)
        {
            Value = playerAction;
        }

    }

    class PlayerActionContextComponent : IPlayerActionContextComponent, IImplementor
    {
        public int Value { get; set; }
    }
}
