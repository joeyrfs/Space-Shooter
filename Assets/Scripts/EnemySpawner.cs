using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    float spawnDistence = 12;
    float enemyRate = 5;
    float nextEnemy = 1;

    // Update is called once per frame
    void Update()
    {
        // Procura o player's ship
        GameObject playerShip = GameObject.FindWithTag("Player");

        nextEnemy -= Time.deltaTime;

        if (nextEnemy <= 0 && playerShip != null)
        {
            nextEnemy = enemyRate;
            enemyRate *= 0.9f;

            if (enemyRate < 2)
            {
                enemyRate = 2;
            }

            Vector3 offset = Random.onUnitSphere;
            offset.z = 0;
            offset = offset.normalized * spawnDistence;
            Instantiate(enemyPrefab, transform.position + offset, Quaternion.identity);
        }
    }
}
