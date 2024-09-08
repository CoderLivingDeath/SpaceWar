using UnityEngine;

namespace Assets.Project.Scripts.Models.Player
{
    public class Player : IPlayer
    {
        public bool IsControlled { get; set; }

        public Rigidbody2D Rigidbody2D { get; }
        public float StepSize { get; }

        public float RotateSpeed { get; }

        public Player(Rigidbody2D rigidbody2D, float stepSize, float rotateSpeed)
        {
            Rigidbody2D = rigidbody2D;
            StepSize = stepSize;
            RotateSpeed = rotateSpeed;
        }

        public void Enable()
        {
            IsControlled = true;
        }

        public void Disable()
        {
            IsControlled = false;
        }
    }
}
