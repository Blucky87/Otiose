using System;
using System.Collections.Generic;
using System.Text;
using Otiose.svelto.entityviews;
using Svelto.ECS;

namespace Core.svelto.entityviews
{
    class TestEntityDescriptor : 
        GenericEntityDescriptor<PhysicsEntityView,
            MovementEntityView,
            PlayerActionSetEntityView,
            PlayerActionLeftStickEntityView,
            PlayerActionRightStickEntityView,
            PlayerActionOneEntityView,
            PlayerActionTwoEntityView>
    {
    }
}
