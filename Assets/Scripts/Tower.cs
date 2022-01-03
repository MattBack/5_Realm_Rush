using System;
using UnityEngine;

public class Tower : MonoBehaviour {

    AudioSource audioSource;

    [SerializeField] Transform objectToPan;
  
    [SerializeField] float attackRange = 10f;
    [SerializeField] ParticleSystem projectileParticle;
    [SerializeField] AudioClip shootSound;

    public Waypoint baseWaypoint; // what the tower is standing on

    Transform targetEnemy;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

	// Update is called once per frame
	void Update () {
        SetTargetEnemy();
        if (targetEnemy)
        {
            objectToPan.LookAt(targetEnemy);
            FireAtEnemy();
        }

        //if (!audioSource.isPlaying)
        //{
        //    audioSource.PlayOneShot(shootSound);
        //}

        else
        {
            Shoot(false);
        }
	}

    private void SetTargetEnemy()
    {
        var sceneEnemies = FindObjectsOfType<EnemyDamage>();
        if (sceneEnemies.Length == 0) { return; }

        Transform closestEnemy = sceneEnemies[0].transform;

        foreach (EnemyDamage testEnemy in sceneEnemies)
        {
            closestEnemy = GetClosest(closestEnemy, testEnemy.transform);
        }

        targetEnemy = closestEnemy;
    }

    private Transform GetClosest(Transform transformA, Transform transformB)
    {
        var disToA = Vector3.Distance(transform.position, transformA.position);
        var disToB = Vector3.Distance(transform.position, transformB.position);

        if (disToA < disToB)
        {
            return transformA;
        }

        return transformB;
    }

    private void FireAtEnemy()
    {
        float distanceToEnemy = Vector3.Distance(targetEnemy.transform.position, gameObject.transform.position);
        if (distanceToEnemy <= attackRange)
        {
            Shoot(true);
        }
        else
        {
            Shoot(false);
        }
    }

    private void Shoot(bool isActive)
    {
        var emissionModule = projectileParticle.emission;
        emissionModule.enabled = isActive;
    }
}
