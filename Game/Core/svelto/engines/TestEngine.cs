using System;
using System.Collections.Generic;
using System.Text;
using Core.svelto.components;
using Svelto.ECS;

namespace Core.svelto.engines
{
    class TestEngine : IEngine, IStep<ActionTwoAxisData>
    {
        public void Step(ref ActionTwoAxisData token, int condition)
        {
            Console.WriteLine($"Entity ID: {token.EntityId}, X: {token.X}, Y: {token.Y}");
        }
    }
}
