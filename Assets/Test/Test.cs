using UnityEngine;

public class Test : MonoBehaviour
{
    public Transform point;

    public Vector2 light;

    public Vector2 reflect;

    public Vector2 SurfaceNormal;

    private void Update()
    {
        light = transform.position - point.position;
        reflect = Vector2.Reflect(light.normalized, SurfaceNormal);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, (Vector2)transform.position + SurfaceNormal);

        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(point.position, transform.position);

        Gizmos.color = Color.green;
        Gizmos.DrawLine(point.position, (Vector2)point.position + reflect.normalized);
        Gizmos.DrawLine(transform.position, (Vector2)transform.position + reflect);
    }
}
