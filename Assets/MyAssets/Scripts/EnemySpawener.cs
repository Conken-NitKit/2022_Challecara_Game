using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using UnityEngine.Serialization;
using Random = System.Random;

public class EnemySpawener : MonoBehaviour
{
    [SerializeField] 
    private CinemachineBrain cmBrain;
    
    [field: SerializeField] 
    public float SpawnFrequency { get; set; }
    
    [field: SerializeField] 
    public GameObject[] spawnEnemies { get; set; }
    
    [SerializeField] private float spawnOffset;
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
        while (true)
        {
           
            Vector2 spawnVector2 = new Vector2();
            if (new Random().Next(1) == 1) spawnVector2.x = spawnOffset + 1;
            else spawnVector2.x = spawnOffset * -1;
            if (new Random().Next(1) == 1) spawnVector2.y = spawnOffset + 1;
            else spawnVector2.y = spawnOffset * -1;

            ICinemachineCamera vCam = cmBrain.ActiveVirtualCamera;
            Vector3 spawnPoint = Camera.main.ViewportToWorldPoint(new Vector3( spawnVector2.x , spawnVector2.y , Camera.main.nearClipPlane));
        
            GameObject randomEnemy = spawnEnemies[UnityEngine.Random.Range(0, spawnEnemies.Length)];
            Instantiate (randomEnemy, spawnPoint, Quaternion.identity);
        
            yield return new WaitForSeconds(SpawnFrequency);
        }
    }
}
