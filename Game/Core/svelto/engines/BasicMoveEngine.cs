using System;
using System.Collections;
using Core.svelto.components;
using Microsoft.Xna.Framework;
using Otiose.svelto.entityviews;
using Svelto.ECS;
using Svelto.Tasks;

namespace Core.svelto.engines
{

    public class BasicMoveEngine : IQueryingEntityViewEngine, IStep<ActionTwoAxisData>
    {
        public IEntityViewsDB entityViewsDB { get; set; }

        public void Ready() { }

        void MoveDriver(ActionTwoAxisData token)
        {
            if (entityViewsDB.TryQueryEntityView(token.EntityId, out MovementEntityView entityView))
            {
                entityView.MovementDriver.X = token.X;
                entityView.MovementDriver.Y = token.Y;
            }
        }

        public void Step(ref ActionTwoAxisData token, int condition)
        {
            MoveDriver(token);
        }

    }
}
