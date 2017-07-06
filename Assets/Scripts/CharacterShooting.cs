using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterShooting : MonoBehaviour
{
    public float bulletSpread = 6f;
    public float kickDuration = 0.025f;
    public float cooldown = 0.1f;
    public float bulletSpeed = 6000f;
    public Transform bulletPrefab;
    public Transform bulletSpawnPosition;

    private CharacterSpriteController spriteController;
    private ICharacterInput input;
    private float timeToGoBackIdle;
    private float timeWhenCanShoot;
    private IShootingAudio shootingAudio;

    private void Start()
    {
        spriteController = GetComponent<CharacterSpriteController>();
        input = GetComponent<ICharacterInput>();
        shootingAudio = GetComponent<IShootingAudio>();
    }

    private void LateUpdate()
    {
        Vector2 shootDirection = spriteController != null ? spriteController.spriteTransform.right : transform.right;
        shootDirection = Quaternion.AngleAxis(Random.Range(-bulletSpread / 2f, bulletSpread / 2f), Vector3.forward) * shootDirection;
        Vector3 spawnPosition = bulletSpawnPosition != null ? bulletSpawnPosition.position : transform.position;
        if(input != null && input.shooting && Time.time > timeWhenCanShoot)
        {
            timeWhenCanShoot = Time.time + cooldown;
            timeToGoBackIdle = Time.time + kickDuration;
            IBullet bullet = Instantiate(bulletPrefab, spawnPosition, Quaternion.identity).RequireComponent<IBullet>();
            bullet.gameObject.transform.parent = Game.clones;
            bullet.gameObject.transform.right = shootDirection;
            bullet.startingVelocity = shootDirection * bulletSpeed;
            bullet.owner = gameObject;
            if(shootingAudio != null)
            {
                shootingAudio.PlayGunshot();
            }
        }
        if (spriteController != null)
        {
            spriteController.kick = Time.time < timeToGoBackIdle;
        }
    }
}

public interface IShootingAudio
{
    void PlayGunshot();
}