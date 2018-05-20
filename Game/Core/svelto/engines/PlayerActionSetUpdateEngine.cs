using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Core.svelto.entityviews;
using Svelto.ECS;
using Svelto.ECS.Internal;
using Svelto.Tasks;

namespace Core.svelto.engines
{
    public class PlayerActionSetUpdateEngine : SingleEntityViewEngine<PlayerActionSetEntityView>
    {
        PlayerActionSetEntityView _playerActionSetEntityView;
        PlayerActionLeftStickEntityView _playerActionLeftStickEntityView;
        private ITaskRoutine _taskRoutine;

        public PlayerActionSetUpdateEngine()
        {
            _taskRoutine = TaskRunner.Instance.AllocateNewTaskRoutine().SetEnumerator(UpdateActionSet());
        }

        IEnumerator UpdateActionSet()
        {
            while (true)
            {
                _playerActionSetEntityView.PlayerActionSet.Value.Update();
                
                yield return null;
            }
        }


        protected override void Add(PlayerActionSetEntityView entityView)
        {
            _playerActionSetEntityView = entityView;
            _taskRoutine.Start();
        }

        protected override void Remove(PlayerActionSetEntityView entityView)
        {
            _taskRoutine.Stop();
            _playerActionSetEntityView = null;
        }

    }
}
