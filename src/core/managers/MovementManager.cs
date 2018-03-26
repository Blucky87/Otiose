using System;
using Core.components;
using Microsoft.Xna.Framework;
using Nez;
using Otiose.Input.Setup;

namespace Core.managers
{
    public class MovementManager
    {
        public static float BeginRun(Entity entity)
        {
            MovementComponent movementComponent = entity.getComponent<MovementComponent>();
            float movementSpeed = movementComponent.MovementSpeed;
            float runSpeedModifier = movementComponent.RunSpeedModifier;

            float runSpeed = movementSpeed * runSpeedModifier;

            entity.getComponent<MovementComponent>().MovementSpeed = runSpeed;
            entity.getComponent<MovementComponent>().IsRunning = true;

            return runSpeed;
        }

        public static bool Run(Entity entity)
        {
            bool isRunning = entity.getComponent<MovementComponent>().IsRunning;
            if (!isRunning)
            {
                BeginRun(entity);
            }

            return entity.getComponent<MovementComponent>().IsRunning;
        }

        public static bool EndRun(Entity entity)
        {
            MovementComponent movementComponent = entity.getComponent<MovementComponent>();
            bool isRunning = movementComponent.IsRunning;
            
            if (isRunning)
            {
                float movementSpeed = movementComponent.MovementSpeed;
                entity.getComponent<MovementComponent>().IsRunning = false;
                entity.getComponent<MovementComponent>().MovementSpeed = 1.0f;
            }

            return entity.getComponent<MovementComponent>().IsRunning;
        }

        public static bool updateFacingAngle(Entity entity)
        {
            PlayerActionSet playerActionSet = entity.getComponent<PlayerActionSetComponent>().PlayerActionSet;

            float angle = playerActionSet.LeftStick.Angle;

            entity.getComponent<MovementComponent>().FacingAngle = angle;
            
            return true;
        }

        public static bool MoveUp(Entity entity)
        {
            MovementComponent movementComponent = entity.getComponent<MovementComponent>();

            if (movementComponent.CanMove)
            {
                entity.position = entity.position + (Vector2.UnitX * movementComponent.MovementSpeed);
            }
            
            Console.WriteLine($"Positon X: {entity.position.X}    Y: {entity.position.Y}");

            return true;
        }

        public static bool MoveDown(Entity entity)
        {
            MovementComponent movementComponent = entity.getComponent<MovementComponent>();

            if (movementComponent.CanMove)
            {
                entity.position = entity.position + (-Vector2.UnitX * movementComponent.MovementSpeed);
            }

            Console.WriteLine($"Positon X: {entity.position.X}    Y: {entity.position.Y}");
            
            return true;
        }

        public static bool MoveLeft(Entity entity)
        {
            MovementComponent movementComponent = entity.getComponent<MovementComponent>();

            if (movementComponent.CanMove)
            {
                entity.position = entity.position + (-Vector2.UnitY * movementComponent.MovementSpeed);
            }

            Console.WriteLine($"Positon X: {entity.position.X}    Y: {entity.position.Y}");
            
            return true;
        }

        public static bool MoveRight(Entity entity)
        {
            MovementComponent movementComponent = entity.getComponent<MovementComponent>();

            if (movementComponent.CanMove)
            {
                entity.position = entity.position + (Vector2.UnitY * movementComponent.MovementSpeed);
            }
            
            Console.WriteLine($"Positon X: {entity.position.X}    Y: {entity.position.Y}");

            return true;
        }
    }
}