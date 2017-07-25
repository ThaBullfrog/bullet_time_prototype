using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Body : MonoBehaviour
{
    public Vector2 startingVelocity;

    private Rigidbody2D rb;

    private void Start()
    {
        rb = this.RequireComponent<Rigidbody2D>();
        rb.velocity = startingVelocity;
    }
}