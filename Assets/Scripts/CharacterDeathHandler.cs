using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterDeathHandler : MonoBehaviour, INeedsDirectionDamagedFrom
{
    public Body bodyPrefab;
    public float fallBackSpeed = 500f;

    public Vector2 directionDamagedFrom { get; set; }

    private void Start()
    {
        var deathAert = GetComponent<IDeathAlert>();
        if(deathAert != null)
        {
            deathAert.onDeath += OnDeath;
        }
    }

    private void OnDeath()
    {
        var body = Instantiate(bodyPrefab, transform.position, Quaternion.identity);
        if(directionDamagedFrom != Vector2.zero)
        {
            body.transform.right = -directionDamagedFrom;
            body.startingVelocity = directionDamagedFrom.normalized * fallBackSpeed;
        }
        var deathAudio = body.GetComponent<AudioSource>();
        if(deathAudio != null)
        {
            deathAudio.Play();
        }
        Destroy(gameObject);
    }
}