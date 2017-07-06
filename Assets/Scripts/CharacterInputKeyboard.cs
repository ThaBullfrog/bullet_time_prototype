using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterInputKeyboard : MonoBehaviour, ICharacterInput
{
    public Vector2 move
    {
        get
        {
            Vector2 move = Vector2.zero;
            if(GetKey(KeyCode.W))
            {
                move.y += 1f;
            }
            if(GetKey(KeyCode.A))
            {
                move.x -= 1f;
            }
            if(GetKey(KeyCode.S))
            {
                move.y -= 1f;
            }
            if(GetKey(KeyCode.D))
            {
                move.x += 1f;
            }
            return move.normalized;
        }
    }

    public Vector2 lookTarget { get { return Camera.main.ScreenToWorldPoint(Input.mousePosition); } }

    public bool shooting { get { return Input.GetMouseButton(0); } }

    private bool GetKey(KeyCode key)
    {
        return Input.GetKey(key);
    }
}