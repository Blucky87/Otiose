using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Core.svelto.components;
using Core.svelto.entityviews;
using Otiose.Input;
using Otiose.svelto.entityviews;
using Svelto.ECS;
using Svelto.Tasks;

namespace Core.svelto.engines
{
    public class PlayerActionLeftStickUpdateEngine : SingleEntityViewEngine<PlayerActionLeftStickEntityView>
    {
        ISequencer  _sequencer;
        ITaskRoutine _taskRoutine;
        PlayerActionLeftStickEntityView _playerActionLeftStickEntityView;

        public PlayerActionLeftStickUpdateEngine(ISequencer sequencer)
        {
            _sequencer = sequencer;
            _taskRoutine = TaskRunner.Instance.AllocateNewTaskRoutine().SetEnumerator(UpdateLeftStickAction());
        }

        IEnumerator UpdateLeftStickAction()
        {
            while (true)
            {
                var ActionTwoAxisData = new ActionTwoAxisData
                {
                    X = _playerActionLeftStickEntityView.LeftStick.Value.X,
                    Y = _playerActionLeftStickEntityView.LeftStick.Value.Y,
                    EntityId = _playerActionLeftStickEntityView.ID
                };

                var playerActionContext = _playerActionLeftStickEntityView.Context.Value;
 
                _sequencer.Next(this, ref ActionTwoAxisData, playerActionContext);

                yield return null;
            }
        }

        protected override void Add(PlayerActionLeftStickEntityView playerActionLeftStickEntityView)
        {
            _playerActionLeftStickEntityView = playerActionLeftStickEntityView;
            _taskRoutine.Start();
        }

        protected override void Remove(PlayerActionLeftStickEntityView leftStickEntityView)
        {
            _taskRoutine.Stop();
            _playerActionLeftStickEntityView = null;
        }
    }
}
