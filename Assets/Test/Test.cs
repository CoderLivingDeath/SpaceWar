using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    public Vector2 vector1;
    public Vector2 vector2;
    public float scale;

    // Update is called once per frame
    void Update()
    {
        Debug.Log(Vector2.Lerp(vector1, vector2, scale));
    }
}
