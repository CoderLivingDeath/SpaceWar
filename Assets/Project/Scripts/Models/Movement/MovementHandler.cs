using UnityEngine;

namespace Assets.Project.Scripts.Models.Movement
{
    public class MovementHandler
    {
        public Vector2 CalculateOffset(Vector2 direction, float stepsize)
        {
            Vector2 offset = direction * Time.deltaTime * stepsize;

            return offset;
        }
    }
}
