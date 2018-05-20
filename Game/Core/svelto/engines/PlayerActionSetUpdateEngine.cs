using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Core.svelto.entityviews;
using Svelto.ECS;
using Svelto.Tasks;

namespace Core.svelto.engines
{
    public class PlayerActionSetUpdateEngine : IQueryingEntityViewEngine
    {
        PlayerActionSetEntityView _playerActionSetEntityView;
        private ITaskRoutine _taskRoutine;
        public IEntityViewsDB entityViewsDB { get; set; }

        public void Ready()
        {
            _taskRoutine.Start();
        }

        public PlayerActionSetUpdateEngine()
        {
            _taskRoutine = TaskRunner.Instance.AllocateNewTaskRoutine().SetEnumerator(UpdateActionSet());
        }

        IEnumerator UpdateActionSet()
        {
            while (true)
            {
                var playerActionSetEntityView = entityViewsDB.QueryEntityViews<PlayerActionSetEntityView>();

                foreach (var entityView in playerActionSetEntityView)
                {
                    var entityId = entityView.ID;

                    //update the PlayerActionSet on the entity
                    entityView.PlayerActionSet.Value.Update();
                    
                    //set the left & right action components to the actionset of the entity
                    LeftStickActionComponentSetup(entityId);
                    RightStickActionComponentSetup(entityId);

                    ActionOneActionComponentSetup(entityId);
                    ActionTwoActionComponentSetup(entityId);
                }
                
                yield return null;
            }
        }

        private void LeftStickActionComponentSetup(EGID entityId)
        {
            if (entityViewsDB.TryQueryEntityView(entityId, out PlayerActionLeftStickEntityView entityView))
                entityView.LeftStick.Value = _playerActionSetEntityView.PlayerActionSet.Value.LeftStick;
        }

        private void RightStickActionComponentSetup(EGID entityId)
        {
            if (entityViewsDB.TryQueryEntityView(entityId, out PlayerActionRightStickEntityView entityView))
                entityView.RightStick.Value = _playerActionSetEntityView.PlayerActionSet.Value.RightStick;
        }

        private void ActionOneActionComponentSetup(EGID entityId)
        {
            if (entityViewsDB.TryQueryEntityView(entityId, out PlayerActionOneEntityView entityView))
                entityView.ActionOne.Value = _playerActionSetEntityView.PlayerActionSet.Value.Action2;
        }

        private void ActionTwoActionComponentSetup(EGID entityId)
        {
            if (entityViewsDB.TryQueryEntityView(entityId, out PlayerActionTwoEntityView entityView))
                entityView.ActionTwo.Value = _playerActionSetEntityView.PlayerActionSet.Value.Action2;
        }
    }
}
