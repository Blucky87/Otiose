using System;
using System.Collections.Generic;
using System.Text;
using Core.svelto.components;
using Svelto.ECS;

namespace Core.svelto.entityviews
{
    public class PlayerActionSetEntityView : EntityView
    {
        public IPlayerActionSet ActionSet;
        public IMoveActionComponent Movement;

        public IPlayerActionSetContextComponent Context;
//        public IAimComponent Aim;
//        public IActionOne ActionOne;
//        public IActionTwo ActionTwo;
    }
}
