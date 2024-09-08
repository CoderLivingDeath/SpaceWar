using UnityEngine;

namespace Assets.Project.Scripts.Models.CharacterController
{
    public class CharacterController2D
    {
        public Vector2 OrientationUp { get; set; }

        public float MoveStepSize { get; set; }

        public float RotationStepSize { get; set; }

        public Rigidbody2D Rigidbody { get; set; }
    }
}
