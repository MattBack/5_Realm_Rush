using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

    [Range(0.1f, 120f)]
    [SerializeField] float secondsBetweenSpawns = 2f;
    [SerializeField] EnemyMovement enemyPrefab;
    [SerializeField] Transform enemyParentTransform;

    // Update is called once per frame
    void Start ()
    {
        StartCoroutine(RepeatedlySpawnEnemies());
	}

    public IEnumerator RepeatedlySpawnEnemies()
    {
        while (true)        // forever
        {
            var newEnemy = Instantiate(enemyPrefab, transform.position, Quaternion.identity);
            newEnemy.transform.parent = enemyParentTransform.transform;
            yield return new WaitForSeconds(secondsBetweenSpawns);
        }
    }

}
