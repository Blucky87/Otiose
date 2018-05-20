using Nez;
using Svelto.ECS.Schedulers;
using Svelto.WeakEvents;

namespace Otiose.svelto
{
    public class MonogameUpdateScheduler : EntitySubmissionScheduler
    {
        private IUpdatableManager _monogameUpdateManager ;

        public MonogameUpdateScheduler()
        {
            _monogameUpdateManager = new MonogameScheduler();

            //register the scheduler with Nez Core Global manager
            Nez.Core.registerGlobalManager(_monogameUpdateManager);

        }

        public override void Schedule(WeakAction submitEntityViews)
        {
            var scheduler = Nez.Core.getGlobalManager<MonogameScheduler>();

            scheduler.UpdateWeakAction = submitEntityViews;
        }

        public class MonogameScheduler : IUpdatableManager
        {
            internal WeakAction UpdateWeakAction;

            public void update()
            {
                if (UpdateWeakAction.IsValid)
                {
                    UpdateWeakAction.Invoke();
                }
            }   
        }
    }
}