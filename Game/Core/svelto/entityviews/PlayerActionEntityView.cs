using System;
using System.Collections.Generic;
using System.Text;
using Core.svelto.components;
using Svelto.ECS;

namespace Core.svelto.entityviews
{
    public class PlayerActionSetEntityView : EntityView
    {
        public IPlayerActionSet PlayerActionSet;
    }

    public class PlayerActionLeftStickEntityView : EntityView
    {
        public IPlayerActionLeftStickComponent LeftStick;
        public IPlayerActionContextComponent Context;
    }

    public class PlayerActionRightStickEntityView : EntityView
    {
        public IPlayerActionRightStickComponent RightStick;
        public IPlayerActionContextComponent Context;
    }

    public class PlayerActionOneEntityView : EntityView
    {
        public IPlayerActionOneComponent ActionOne;
        public IPlayerActionContextComponent Context;
    }

    public class PlayerActionTwoEntityView : EntityView
    {
        public IPlayerActionTwoComponent ActionTwo;
        public IPlayerActionContextComponent Context;
    }
}
