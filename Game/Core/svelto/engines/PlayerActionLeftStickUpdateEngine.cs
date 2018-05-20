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
    public class PlayerActionLeftStickUpdateEngine : SingleEntityViewEngine<PlayerActionLeftStickEntityView>
    {
        ISequencer  _sequencer;
        ITaskRoutine _taskRoutine;
        PlayerActionLeftStickEntityView _playerActionLeftStickEntityView;

        public PlayerActionLeftStickUpdateEngine(ISequencer sequencer)
        {
            _sequencer = sequencer;
            _taskRoutine = TaskRunner.Instance.AllocateNewTaskRoutine().SetEnumerator(UpdateActionSet());
        }

        IEnumerator UpdateActionSet()
        {
            while (true)
            {
                
 

//                _sequencer.Next(this, ref leftStick, playerActionContext);

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
