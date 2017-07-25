using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public Sprite openSprite;

    private Collider2D myCollider;
    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        myCollider = GetComponent<Collider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(Game.player != null && (collision.collider.transform == Game.player || collision.otherCollider.transform == Game.player))
        {
            myCollider.enabled = false;
            if(spriteRenderer != null)
            {
                spriteRenderer.sprite = openSprite;
            }
        }
    }
}