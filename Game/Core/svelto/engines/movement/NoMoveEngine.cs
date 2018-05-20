using Svelto.ECS;

namespace Otiose.svelto.engines
{
    public class NoMoveEngine : IQueryingEntityViewEngine, IStep<MovementInfo>
    {
        public IEntityViewsDB entityViewsDB { get; set; }
        public void Ready()
        {
            
        }


        public void Step(ref MovementInfo token, int condition)
        {
            
        }
    }
}