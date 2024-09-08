using Assets.Project.Scripts.Models.Movement;
using Assets.Project.Scripts.Models.Player;
using Assets.Project.Scripts.Models.Rotation;
using UnityEngine;

namespace Assets.Project.Scripts.Services
{
    public class PlayerControllService
    {
        private MovementHandler _movementHandler;
        private RotationHandler _rotationHandler;

        public PlayerControllService(MovementHandler movementHandler, RotationHandler rotationHandler)
        {
            _movementHandler = movementHandler;
            _rotationHandler = rotationHandler;
        }

        public void MovePlayer(IPlayer player, Vector2 direction)
        {
            Vector2 offset = _movementHandler.CalculateOffset(direction, player.StepSize);
            Vector2 newPosition = player.Rigidbody2D.position + offset;
            player.Rigidbody2D.MovePosition(newPosition);
        }

        public void RotatePlayer(IPlayer player, Vector2 direction, float correctAngle = 0)
        {
            float angle = _rotationHandler.CalculateAngleToPoint(direction);
            player.Rigidbody2D.SetRotation(angle + correctAngle);
        }
    }
}
