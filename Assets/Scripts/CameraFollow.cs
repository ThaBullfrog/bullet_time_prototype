using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform follow;

    private void LateUpdate()
    {
        if (follow != null)
        {
            transform.position = new Vector3(follow.position.x, follow.position.y, transform.position.z);
        }
    }
}