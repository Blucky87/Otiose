using Nez;

namespace Core.actions
{
    public abstract class EntityControlAction : EmptyControlAction
    {
        protected readonly Entity _entity;

        public EntityControlAction(Entity entity)
        {
            _entity = entity;
        }
    }
}