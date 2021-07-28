using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAndDie : MonoBehaviour
{
    public Vector3 movement;
    public float lifespan;
    public Note sibling_note;

    private void Start()
    {
        Destroy(gameObject, lifespan);
    }

    void FixedUpdate()
    {
        transform.position += movement;
    }
}
