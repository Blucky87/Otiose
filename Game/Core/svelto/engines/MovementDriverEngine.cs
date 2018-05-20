using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Core.svelto.entityviews;
using Microsoft.Xna.Framework;
using Otiose.svelto.entityviews;
using Svelto.ECS;
using Svelto.Tasks;

namespace Core.svelto.engines
{
    public class MovementDriverEngine : SingleEntityViewEngine<PhysicsEntityView>
    {
        public MovementDriverEngine()
        {
            _taskRoutine = TaskRunner.Instance.AllocateNewTaskRoutine().SetEnumerator(MoveDriver());
        }


        IEnumerator MoveDriver()
        {
            while (true)
            {
                var forceX = _PhysicsEntityView.MovementDriver.X;
                var forceY = _PhysicsEntityView.MovementDriver.Y;

                _PhysicsEntityView.Force.Force = new Vector2(forceX, forceY);

                //                Console.WriteLine(new Vector2(_movementEntityView.MovementDriverComponent.X,_movementEntityView.MovementDriverComponent.Y));

                yield return null;
            }
        }

        protected override void Add(PhysicsEntityView entityView)
        {
            _PhysicsEntityView = entityView;
            _taskRoutine.Start();
        }

        protected override void Remove(PhysicsEntityView entityView)
        {
            _taskRoutine.Stop();
            _PhysicsEntityView = null;
        }

        ITaskRoutine _taskRoutine;
        PhysicsEntityView _PhysicsEntityView;
    }
}
