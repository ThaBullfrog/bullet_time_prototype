using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{

    public float speed = 100f;

    private ICharacterInput input;
    private Rigidbody2D rb;
    private SpriteController sprite;

    private void Start()
    {
        input = GetComponent<ICharacterInput>();
        rb = this.RequireComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteController>();
    }

    private void FixedUpdate()
    {
        rb.velocity = Vector2.zero;
        if(input != null)
        {
            rb.velocity = input.move * speed;
        }
    }

    private void Update()
    {
        if (input != null)
        {
            sprite.spriteTransform.right = (input.lookTarget.Vector3() - transform.position).normalized;
        }
    }

}