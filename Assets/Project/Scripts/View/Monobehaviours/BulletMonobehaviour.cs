using Assets.Project.Scripts.Services.WeaponServices;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class BulletMonobehaviour : MonoBehaviour
{
    [field: SerializeField] public Rigidbody2D Rigidbody2D { get; set; }
    [field: SerializeField] public Collider2D Collider2D { get; set; }
    [field: SerializeField] public CollisionEventProvider CollisionEventProvider { get; set; }
    [field: SerializeField] public BulletShot Bullet { get; set; }

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
        throw new System.NotImplementedException();
    }
    private void CollisionEventProvider_Exit(Collision2D obj)
    {
        throw new System.NotImplementedException();
    }

    private void OnEnable()
    {
        SubscribeOnCollisionUpdate();
    }

    private void OnDisable()
    {
        UnSubscribeOnCollisionUpdate();
    }
}
