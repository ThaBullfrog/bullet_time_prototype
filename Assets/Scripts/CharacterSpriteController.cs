using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSpriteController : SpriteController
{
    public Sprite idleSprite;
    public Sprite kickSprite;

    private SpriteRenderer spriteRenderer;

    public bool kick
    {
        get { return spriteRenderer.sprite == kickSprite; }
        set
        {
            if (value)
            {
                spriteRenderer.sprite = kickSprite;
            }
            else
            {
                spriteRenderer.sprite = idleSprite;
            }
        }
    }

    private void Start()
    {
        spriteRenderer = spriteTransform.RequireComponent<SpriteRenderer>();
    }
}