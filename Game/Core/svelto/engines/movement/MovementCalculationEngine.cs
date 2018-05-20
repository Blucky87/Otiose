using Otiose.svelto.components;
using Otiose.svelto.entityviews;
using Svelto.ECS;

namespace Otiose.svelto.engines
{
    public class MovementCalculationEngine : IQueryingEntityViewEngine, IStep<MovementInfo>
    {
        public IEntityViewsDB entityViewsDB { get; set; }
        public void Ready()
        {
           
        }

        public void Step(ref MovementInfo token, int condition)
        {

            CalculateNewPosition(token);
        }

        private void CalculateNewPosition(MovementInfo token)
        {
            EGID entityModifierID = token.EntityMovementId;
//            var entity = entityViewsDB.QueryEntityView<PlayerActionLeftStickEntityView>(entityModifierID);

//            entity.PositionComponent.X = CalculatedPositionX(token);
//            entity.PositionComponent.Y = CalculatedPositionY(token);
        }

        private float CalculatedPositionX(MovementInfo token)
        {
            return token.RunSpeed * token.Position.X;
        }
    }


    // (check if entity can move at all) -> (check direction to move) -> (check speed to move) -> (calculate where to move) -> (move to calculated place)
}