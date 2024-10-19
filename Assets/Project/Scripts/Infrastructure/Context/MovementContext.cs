using UnityEditor.Rendering.Universal;
using UnityEngine;

namespace Assets.Project.Scripts.Controllers.MovementController
{
    public class MovementContext
    {
        public readonly Vector2 CurrentPosition;

        public readonly Vector2 Direction;
        public readonly float StepSize;

        public MovementContext(Vector2 currentPosition, Vector2 direction, float stepSize)
        {
            CurrentPosition = currentPosition;
            Direction = direction;
            StepSize = stepSize;
        }
    }
}