using System;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class CollisionEventProvider : MonoBehaviour
{
    public event Action<Collision2D> Enter;
    public event Action<Collision2D> Stay;
    public event Action<Collision2D> Exit;

    private Collider2D _collider;

    private void Start()
    {
        _collider = GetComponent<Collider2D>();
        if (_collider.isTrigger == true)
        {
            throw new Exception("Колайдер не должен быть IsTrigger.");
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Enter?.Invoke(collision);
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        Exit?.Invoke(collision);
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        Stay?.Invoke(collision);
    }
}