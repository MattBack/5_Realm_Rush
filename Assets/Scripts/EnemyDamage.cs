using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour {

    [SerializeField] int scorePerHit = 10;
    [SerializeField] int hits = 3;
    [SerializeField] ParticleSystem hitParticlePrefab;
    [SerializeField] ParticleSystem deathParticlePrefab;
    [SerializeField] AudioClip enemyDamageSFX;
    [SerializeField] AudioClip enemyDeathSFX;

    AudioSource myAudioSource;

    void Start() {
        AddBoxCollider();
        myAudioSource = GetComponent<AudioSource>();
    }

    private void AddBoxCollider()
    {
        Collider boxCollider = gameObject.AddComponent<BoxCollider>();
        boxCollider.isTrigger = false;
    }

    void OnParticleCollision(GameObject other)
    {
        ProcessHit();
        if (hits <= 0)
        {
            KillEnemy();
            
        }
    }

    private void ProcessHit()
    {
        hits = hits - 1;
        hitParticlePrefab.Play();
        myAudioSource.PlayOneShot(enemyDamageSFX);
    }

    private void KillEnemy()
    {
        
        var vfx = Instantiate(deathParticlePrefab, transform.position, Quaternion.identity);
        vfx.Play();
        Destroy(vfx.gameObject, vfx.main.duration);
        AudioSource.PlayClipAtPoint(enemyDeathSFX, Camera.main.transform.position);
        Destroy(gameObject, 3);
        
    }
 

  }
