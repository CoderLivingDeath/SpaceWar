using UnityEngine;

namespace Assets.Project.Scripts.Services
{
    public class MovementService : IMovementService
    {
        public Vector2 CalculateOffset(Vector2 moveVector, float stepSize, float deltaTime, float timeScale)
        {
            return moveVector * stepSize * timeScale;
        }
    }
}
