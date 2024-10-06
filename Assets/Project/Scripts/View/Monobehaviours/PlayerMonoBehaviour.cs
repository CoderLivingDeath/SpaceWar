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

        [Range(0, 0.9f)]
        [field: SerializeField] public float LerpScale = 0.5f;

        [field: SerializeField] public Space Space = Space.Self;

        [field: SerializeField] public float CorrectRotationAngle = -90;

        public BulletShotConfig bullet;
        public Transform ShootPoint;

        public float speed;

        private IEventBus _eventBus;

        private Vector2 _inputMoveVector;
        private Vector2 _oldMoveVecotor;

        private Vector2 MoveVector;

        private MovementController _movementController;

        private BulletSpawner _bulletSpawner;

        [Inject]
        public void Construct(IEventBus eventBus, MovementController movementController, BulletSpawner bulletSpawner)
        {
            _eventBus = eventBus;
            _movementController = movementController;
            _bulletSpawner = bulletSpawner;
        }

        private void MoveProcess(Vector2 direction)
        {
            Vector2 currentPosition = Rigidbody.position;
            Vector2 currentVelocity = Rigidbody.velocity;
            Vector2 inputVector = _inputMoveVector;
            Vector2 oldMoveVector = _oldMoveVecotor;
            float gravityScale = Rigidbody.gravityScale;
            float lerpScale = Mathf.Clamp(LerpScale, 0, 1f);
            float stepSize = StepSize;

            MovementContext context = new(currentPosition, currentVelocity, inputVector, oldMoveVector, gravityScale, lerpScale, StepSize);

            MovementResult result = _movementController.Move(context);
            result.Changes.ApplyChanges(Rigidbody);

            speed = result.NewMoveVector.magnitude - _oldMoveVecotor.magnitude;
            _oldMoveVecotor = result.NewMoveVector;

        }

        public void RotationProcess(Vector2 To, float angleCorrect)
        {
            Vector2 direction = (Vector2)transform.position - (Vector2)transform.position + To.normalized;
            var angle = Mathf.Atan2(To.y, To.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, 0, angle + angleCorrect);

        }

        private void shootProcces()
        {
            _bulletSpawner.Spawn(bullet, ShootPoint.position, transform.rotation);
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
            shootProcces();
        }

        #region Unity methods

        private void FixedUpdate()
        {
            MoveProcess(_inputMoveVector);
            RotationProcess(_oldMoveVecotor, CorrectRotationAngle);
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
            Gizmos.color = Color.yellow;
            Gizmos.DrawLine(transform.position, (Vector2)transform.position + _oldMoveVecotor.normalized);
            Gizmos.DrawSphere((Vector2)transform.position + _oldMoveVecotor.normalized, 0.08f);

            Gizmos.color = Color.red;
            Gizmos.DrawLine(transform.position, (Vector2)transform.position + _oldMoveVecotor);
            Gizmos.DrawSphere((Vector2)transform.position + _oldMoveVecotor, 0.05f);
        }
        #endregion
    }
}
