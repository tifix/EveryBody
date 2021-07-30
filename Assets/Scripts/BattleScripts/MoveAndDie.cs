using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAndDie : MonoBehaviour
{
    public Vector3 movement;
    public float lifespan;

    public virtual void Start()
    {
        Destroy(gameObject, lifespan);
    }

    public virtual void FixedUpdate()
    {
        transform.position += movement;
    }
}
