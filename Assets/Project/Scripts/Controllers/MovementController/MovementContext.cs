using UnityEngine;

namespace Assets.Project.Scripts.Controllers.MovementController
{
    public class MovementContext
    {
        public readonly Vector2 CurrentPosition;
        public readonly Vector2 CurrentVelocity;

        public readonly Vector2 InputVector;

        public readonly Vector2 OldMoveVector;

        public readonly float GravityScale;
        public readonly float LerpScale;
        public readonly float StepSize;

        public MovementContext(Vector2 currentPosition, Vector2 currentVelocity, Vector2 inputVector, Vector2 oldMoveVector, float gravityScale, float lerpScale, float stepSize)
        {
            CurrentPosition = currentPosition;
            CurrentVelocity = currentVelocity;
            InputVector = inputVector;
            OldMoveVector = oldMoveVector;
            GravityScale = gravityScale;
            LerpScale = lerpScale;
            StepSize = stepSize;
        }
    }
}