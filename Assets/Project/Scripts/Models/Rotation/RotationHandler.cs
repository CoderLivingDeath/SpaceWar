using UnityEngine;

namespace Assets.Project.Scripts.Models.Rotation
{
    public class RotationHandler
    {
        public float CalculateAngleToPoint(Vector2 at)
        {
            float angle = Mathf.Atan2(at.y, at.x) * Mathf.Rad2Deg;
            return angle;
        }

        private Vector2 GetPerpendicularVector(Vector2 vector)
        {
            return new Vector2(vector.y, -vector.x);
        }
    }
}
