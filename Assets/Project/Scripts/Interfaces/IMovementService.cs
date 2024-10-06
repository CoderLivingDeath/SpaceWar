using UnityEngine;

namespace Assets.Project.Scripts.Services
{
    public interface IMovementService
    {
        Vector2 CalculateMoveVector(Vector2 newInput, Vector2 oldInput, float scale);
        Vector2 CalculateOffset(Vector2 moveVector, float stepSize, float deltaTime, float timeScale);
    }
}