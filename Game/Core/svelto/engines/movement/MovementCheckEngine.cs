using System;
using System.Collections;
using Otiose.svelto.entityviews;
using Svelto.ECS;
using Svelto.Tasks;

namespace Otiose.svelto.engines
{
    public class MovementCheckEngine : SingleEntityViewEngine<MovementEntityView>, IQueryingEntityViewEngine
    {
        public IEntityViewsDB entityViewsDB { private get; set; }
        private readonly ISequencer _sequencer;
        private ITaskRoutine _taskRoutine;

        public MovementCheckEngine(ISequencer sequencer )
        {
            
            _sequencer = sequencer;
            _taskRoutine = TaskRunner.Instance.AllocateNewTaskRoutine().SetEnumerator(Tick())
                .SetScheduler(StandardSchedulers.multiThreadScheduler);
        }

        IEnumerator Tick()
        {
            while (true)
            {
                var moveableEntities = entityViewsDB.QueryEntityViews<MovementEntityView>();

                foreach (var entity in moveableEntities)
                {
                    if (entity.MovementInputComponent.AngleDeg > 0)
                    {
                        Console.WriteLine($"Entity attempting to move");
                        var able = CheckIfAbleToMove(entity);
                        var movementInfo = new MovementInfo(entity.ID);

                        if (able)
                        {
                            _sequencer.Next(this, ref movementInfo, MovementCondition.CanMove);
                        }
                        else
                        {
                            _sequencer.Next(this, ref movementInfo, MovementCondition.CanNotMove);
                        }
                    }
                }

                yield return null;
            }
        }

        private bool CheckIfAbleToMove(MovementEntityView entity)
        {
            return true;
        }

        public void Ready()
        { }

        protected override void Add(MovementEntityView entityView)
        {
            _taskRoutine.Start();
        }

        protected override void Remove(MovementEntityView entityView)
        {
            _taskRoutine.Stop();
        }
    }
}