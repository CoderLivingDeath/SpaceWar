using Assets.Project.Scripts.Controllers;
using Assets.Project.Scripts.Models.EventBus;
using Assets.Project.Scripts.Models.EventBus.EventHandlers.HandlersGroup;
using Assets.Project.Scripts.Models.Player;
using UnityEngine;
using Zenject;

namespace Assets.Project.Scripts.View.MonoBehaviours
{
    public class PlayerMonoBehaviour : MonoBehaviour, IPlayerInputHandlers
    {
        [field: SerializeField] public Rigidbody2D Rigidbody { get; private set; }
        [field: SerializeField] public Collider2D Collider { get; private set; }

        [field: SerializeField] public float speed = 20f;

        [field: SerializeField] public float MoveVectorRotation = 0.5f;

        [field: SerializeField] public Space Space = Space.Self;

        [field: SerializeField] public float CorrectRotationAngle = -90;

        private Vector2 InputMoveVector;

        private Vector2 MoveVector;

        private EventBus _eventBus;

        private PlayerController _playerController;

        private IPlayer _player;

        private void RotateProcess(Vector2 direction, float correctAngle = -90)
        {
            _playerController.RotatePlayer(_player, direction, correctAngle);
        }

        private void MoveProcess(Vector2 direction)
        {
            _playerController.MovePlayer(_player, direction);
        }

        private void shootProcces()
        {
        }

        [Inject]
        private void Construct(EventBus eventBus, PlayerController playerController)
        {
            _eventBus = eventBus;
            _playerController = playerController;
            _player = new Player(Rigidbody, speed, MoveVectorRotation);
        }

        private Vector2 CalculateMoveVector(Vector2 direction)
        {
            return Vector2.Lerp(MoveVector, direction, MoveVectorRotation);
        }

        private void FixedUpdate()
        {
            MoveVector = CalculateMoveVector(InputMoveVector);
            MoveProcess(MoveVector);
            RotateProcess(MoveVector, CorrectRotationAngle);
        }

        private void OnEnable()
        {
            _eventBus.Subscribe(this);
        }

        private void OnDisable()
        {
            _eventBus.Unsubscribe(this);
        }

        private void OnDestroy()
        {
            _eventBus.Unsubscribe(this);
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawLine(transform.position, (Vector2)transform.position + InputMoveVector * 3);
            Gizmos.color = Color.yellow;
            Gizmos.DrawLine(transform.position, (Vector2)transform.position + MoveVector * 3);
        }

        public void HandlePlayerMovement(Vector2 direction)
        {
            switch (Space)
            {
                case Space.World:
                    InputMoveVector = direction;
                    break;
                case Space.Self:
                    InputMoveVector = transform.worldToLocalMatrix.inverse * direction;
                    break;
                default:
                    throw new System.Exception();
            }
        }

        public void HandlePlayerRotate(Vector2 direction)
        {
        }

        public void HandlePlayerShoot()
        {
            shootProcces();
        }
    }
}
