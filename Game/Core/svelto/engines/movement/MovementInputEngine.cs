using Otiose.svelto.entityviews;
using Svelto.ECS;

namespace Otiose.svelto.engines
{
    public class MovementInputEngine : IQueryingEntityViewEngine, IStep<MovementInfo>
    {
        public IEntityViewsDB entityViewsDB { get; set; }
        public void Ready()
        {
            
        }


        public void Step(ref MovementInfo token, int condition)
        {
            var entity = entityViewsDB.QueryEntityView<MovementEntityView>(token.EntityMovementId);

            
        }
    }
}