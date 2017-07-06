using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAudio : MonoBehaviour, IShootingAudio
{
    public AudioSource gunshots;
    
    public void PlayGunshot()
    {
        gunshots.Play();
    }
}