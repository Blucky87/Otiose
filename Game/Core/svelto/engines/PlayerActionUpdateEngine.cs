using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Core.svelto.components;
using Core.svelto.entityviews;
using Otiose.svelto.entityviews;
using Svelto.ECS;
using Svelto.Tasks;

namespace Core.svelto.engines
{
    public class PlayerActionUpdateEngine : SingleEntityViewEngine<PlayerActionSetEntityView>
    {
        ISequencer  _sequencer;
        ITaskRoutine _taskRoutine;
        PlayerActionSetEntityView _playerActionSetEntityView;

        public PlayerActionUpdateEngine(ISequencer sequencer)
        {
            _sequencer = sequencer;
            _taskRoutine = TaskRunner.Instance.AllocateNewTaskRoutine().SetEnumerator(UpdateActionSet());
        }

        IEnumerator UpdateActionSet()
        {
            while (true)
            {
                _playerActionSetEntityView.ActionSet.Value.Update();

                var leftStick = new ActionTwoAxisData
                {
                    EntityId = _playerActionSetEntityView.ID,
                    X = _playerActionSetEntityView.ActionSet.Value.LeftStick.X,
                    Y = _playerActionSetEntityView.ActionSet.Value.LeftStick.Y
                };

                var playerActionContext = _playerActionSetEntityView.Context.Value;

                _sequencer.Next(this, ref leftStick, playerActionContext);

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
