using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using UnityEngine.Serialization;
using Random = System.Random;

public class EnemySpawener : MonoBehaviour
{
    [field: SerializeField] 
    public float SpawnFrequency { get; set; }
    
    [field: SerializeField] 
    public GameObject[] spawnEnemies { get; set; }
    
    [SerializeField] private Vector3 spawnRange;
    private Vector3 camArea;
    private void Start()
    {
        StartCoroutine(nameof(SpawnEnemy));
    }
    
    public void StopSpawn()
    {
        StopCoroutine(nameof(SpawnEnemy));
    }

    private IEnumerator SpawnEnemy()
    {
        Random rand = new Random();
        while (true)
        {
            Vector2 spawnVector2 = new Vector2();
            if (rand.NextDouble() > 0.5)
            {
                Debug.Log("x");
                double offset = spawnRange.x * rand.NextDouble();
                if (rand.NextDouble() > 0.5)
                {
                    spawnVector2.x = (float) offset * -1;
                }else
                {
                    spawnVector2.x = (float) offset + 1;
                }

                spawnVector2.y = (float) rand.NextDouble() * (spawnRange.y * 2 + 1) - spawnRange.y;
            }
            else
            {
                Debug.Log("y");

                double offset = spawnRange.x * rand.NextDouble();
                if (rand.NextDouble() > 0.5)
                {
                    spawnVector2.y = (float) offset * -1;
                }else
                {
                    spawnVector2.y = (float) offset + 1;
                }

                spawnVector2.x = (float) rand.NextDouble() * (spawnRange.x * 2 + 1) - spawnRange.x;
            }
            Debug.Log($"{spawnVector2.x} {spawnVector2.y}");
            Vector3 spawnPoint = Camera.main.ViewportToWorldPoint(new Vector3( spawnVector2.x , spawnVector2.y ,(float)(50 * rand.NextDouble() - 25 )));
        
            GameObject randomEnemy = spawnEnemies[UnityEngine.Random.Range(0, spawnEnemies.Length)];
            Instantiate (randomEnemy, spawnPoint, Quaternion.identity);
        
            yield return new WaitForSeconds(SpawnFrequency);
        }
    }
}
