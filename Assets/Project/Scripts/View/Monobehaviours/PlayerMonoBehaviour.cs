using Assets.Project.Scripts.Controllers.MovementController;
using Assets.Project.Scripts.Controllers.ShootController;
using Assets.Project.Scripts.Infrastructure.Spawner;
using Assets.Project.Scripts.Models.EventBus;
using Assets.Project.Scripts.Models.EventBus.EventHandlers.HandlersGroup;
using UnityEngine;
using Zenject;

namespace Assets.Project.Scripts.View.MonoBehaviours
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class PlayerMonoBehaviour : MonoBehaviour, IPlayerInputHandlers
    {
        [field: SerializeField] public Rigidbody2D Rigidbody { get; private set; }
        [field: SerializeField] public Collider2D Collider { get; private set; }

        [field: SerializeField] public float StepSize = 20f;

        [field: SerializeField] public float LerpScale = 0.9f;

        [field: SerializeField] public Space Space = Space.Self;

        [field: SerializeField] public float CorrectRotationAngle = -90;
        [field: SerializeField] public Vector2 SpeedVector;
        [field: SerializeField] public float Speed;

        private IEventBus _eventBus;

        private Vector2 _inputMoveVector;

        private Vector2 _moveVector;

        private Vector2 _rotationVector;
        private Vector2 _prevPosition;
        private MovementController _movementController;

        public BulletShotConfig config;
        public BulletSpawner bulletSpawner;

        public Transform BulletSpawnPoint;

        [Inject]
        public void Construct(IEventBus eventBus, MovementController movementController, BulletSpawner spawner)
        {
            _eventBus = eventBus;
            _movementController = movementController;
            bulletSpawner = spawner;
        }

        private void MoveProcess(Vector2 direction)
        {
            Vector2 currentPosition = Rigidbody.position;
            Vector2 inputVector = _moveVector;
            float stepSize = StepSize;

            MovementContext context = new(currentPosition, inputVector, StepSize);

            MovementResult result = _movementController.Move(context);

            Rigidbody.MovePosition(Rigidbody.position + result.NewOffset);
        }

        private void RotationProcess(Vector2 To, float angleCorrect)
        {
            Vector2 direction = (Vector2)transform.position - (Vector2)transform.position + To.normalized;
            var angle = Mathf.Atan2(To.y, To.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, 0, angle + angleCorrect);
        }

        private void shootProcces(Vector2 direction)
        {
            var bullet = bulletSpawner.Spawn(config, BulletSpawnPoint.position, this.transform.rotation);
            var BulletMonoBehaviour = bullet.GetComponent<BulletMonobehaviour>();
            var BulletRigidBody = bullet.GetComponent<Rigidbody2D>();
            BulletMonoBehaviour.MovementDirection = direction;
            //BulletMonoBehaviour.Vecloity = transform.up;
        }

        public void HandlePlayerMovement(Vector2 direction)
        {
            switch (Space)
            {
                case Space.World:
                    _inputMoveVector = direction;
                    break;
                case Space.Self:
                    _inputMoveVector = transform.worldToLocalMatrix.inverse * direction;
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
            shootProcces(transform.up);
        }

        #region Unity methods

        private void FixedUpdate()
        {
            SpeedVector = (Vector2)transform.position - _prevPosition;
            Speed = SpeedVector.magnitude;

            MoveProcess(_inputMoveVector);

            _moveVector = Vector2.Lerp(_inputMoveVector, _moveVector, LerpScale);

            if (_moveVector.magnitude > 0.1f)
                _rotationVector = _moveVector.normalized;

            RotationProcess(_rotationVector, CorrectRotationAngle);

            _prevPosition = transform.position;
        }

        private void OnEnable()
        {
            _eventBus.Subscribe(this);
        }

        private void OnDisable()
        {
            _eventBus.Unsubscribe(this);
        }

        private void OnDrawGizmos()
        {
        }
        #endregion
    }
}
