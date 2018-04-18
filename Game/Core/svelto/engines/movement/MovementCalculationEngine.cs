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
            EGID entityModifierID = token.EntityMovementId;
            var entity = entityViewsDB.QueryEntityView<MovementEntityView>(entityModifierID);
            token.EntityMovementId
            entity.MovementInputComponent
        }
    }
}