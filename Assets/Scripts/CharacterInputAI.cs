using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterInputAI : MonoBehaviour, ICharacterInput
{
    public Vector2 move { get { return Vector2.zero; } }
    public LayerMask layerMask;

    private Vector2 lastLookTarget = Vector2.zero;
    public Vector2 lookTarget
    {
        get
        {
            if (Game.player != null)
            {
                lastLookTarget = Game.player.position;
            }
            return lastLookTarget;
        }
    }

    public bool shooting
    {
        get
        {
            if (Game.player != null)
            {
                float radius = 7f;
                Vector2 origin = transform.position;
                Vector2 vectorToPlayer = Game.player.position - transform.position;
                Vector2 direction = vectorToPlayer.normalized;
                float distance = vectorToPlayer.magnitude;
                int oldLayer = gameObject.layer;
                gameObject.layer = LayerMask.NameToLayer("NoCollide");
                RaycastHit2D hit = Physics2D.CircleCast(origin, radius, direction, distance, layerMask);
                gameObject.layer = oldLayer;
                if(hit.collider.transform == Game.player)
                {
                    return true;
                }
            }
            return false;
        }
    }
}