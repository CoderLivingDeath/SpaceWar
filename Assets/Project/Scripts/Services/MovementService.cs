using UnityEngine;

namespace Assets.Project.Scripts.Services
{
    public class MovementService : IMovementService
    {
        public Vector2 CalculateMoveVector(Vector2 newInput, Vector2 oldInput, float LerpScale)
        {
            return Vector2.Lerp(newInput,oldInput , LerpScale);
        }

        public Vector2 CalculateOffset(Vector2 moveVector, float stepSize, float deltaTime, float timeScale)
        {
            return moveVector * stepSize * timeScale;
        }
    }
}
