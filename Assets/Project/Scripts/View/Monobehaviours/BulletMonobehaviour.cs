using Assets.Project.Scripts.Controllers.MovementController;
using Assets.Project.Scripts.Models.Weapon;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

[RequireComponent(typeof(Rigidbody2D))]
public class BulletMonobehaviour : MonoBehaviour
{
    [field: SerializeField] public Rigidbody2D Rigidbody2D { get; set; }
    [field: SerializeField] public Collider2D Collider2D { get; set; }
    [field: SerializeField] public CollisionEventProvider CollisionEventProvider { get; set; }
    [field: SerializeField] public BulletShot Bullet { get; set; }

    [field: SerializeField] public Vector2 MovementDirection { get ; set; }
    [field: SerializeField] public float LerpScale { get; set; } = 0.9f;
    [field: SerializeField] public float StepSize { get; set; } = 0.9f;

    private Vector2 _moveVector;

    public HashSet<Vector2> points = new HashSet<Vector2>();

    public bool IsKinematik => Rigidbody2D.isKinematic;

    private MovementController _moveController;

    [Inject]
    private void Construct(MovementController controller)
    {
        _moveController = controller;
    }

    private void KinematicPhysicProcess(Vector2 velocity)
    {
        Vector2 currentPosition = Rigidbody2D.position;
        Vector2 moveVector = _moveVector;
        float stepSize = StepSize;
        MovementContext context = new(currentPosition, moveVector, stepSize);

        var result = _moveController.Move(context);

        Rigidbody2D.MovePosition(Rigidbody2D.position + result.NewOffset);
    }

    private void SubscribeOnCollisionUpdate()
    {
        CollisionEventProvider.Enter += CollisionEventProvider_Enter;
        CollisionEventProvider.Exit += CollisionEventProvider_Exit;
    }

    private void UnSubscribeOnCollisionUpdate()
    {
        CollisionEventProvider.Enter -= CollisionEventProvider_Enter;
        CollisionEventProvider.Exit -= CollisionEventProvider_Exit;
    }

    private void CollisionEventProvider_Enter(Collision2D obj)
    {
        this.Rigidbody2D.bodyType = RigidbodyType2D.Dynamic;

        var contact = obj.contacts[0];
        MovementDirection = Vector2.Reflect(MovementDirection, contact.normal);
    }
    private void CollisionEventProvider_Exit(Collision2D obj)
    {
    }

    private void FixedUpdate()
    {
        if (true)
        {
            _moveVector = Vector2.Lerp(MovementDirection, _moveVector, LerpScale);
            KinematicPhysicProcess(MovementDirection);
        }
    }

    private void OnEnable()
    {
        SubscribeOnCollisionUpdate();
    }

    private void OnDisable()
    {
        UnSubscribeOnCollisionUpdate();
    }

    private void OnDrawGizmos()
    {
    }
}
