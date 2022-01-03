using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour {

    [SerializeField] int scorePerHit = 10;
    [SerializeField] int hits = 3;
    [SerializeField] ParticleSystem hitParticlePrefab;
    [SerializeField] ParticleSystem deathParticlePrefab;

    // Use this for initialization
    void Start() {
        AddBoxCollider();
    }

    private void AddBoxCollider()
    {
        Collider boxCollider = gameObject.AddComponent<BoxCollider>();
        boxCollider.isTrigger = false;
    }

    // Update is called once per frame
    void Update() {

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
    }

    private void KillEnemy()
    {
        
        var vfx = Instantiate(deathParticlePrefab, transform.position, Quaternion.identity);
        vfx.Play();

        Destroy(vfx.gameObject, vfx.main.duration);
        Destroy(gameObject, 3);
        
    }
 

  }
