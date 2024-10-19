using UnityEngine;

namespace Assets.Project.Scripts.Services
{
    public interface IMovementService
    {
        Vector2 CalculateOffset(Vector2 direction, float stepSize, float deltaTime, float timeScale);
    }
}