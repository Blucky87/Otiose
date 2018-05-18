using System;
using System.Collections.Generic;
using System.Text;
using Svelto.ECS;

namespace Core.svelto.engines
{
    class PhysicsEngine : IQueryingEntityViewEngine
    {
        public IEntityViewsDB entityViewsDB { get; set; }
        public void Ready()
        {
        }


    }
}
