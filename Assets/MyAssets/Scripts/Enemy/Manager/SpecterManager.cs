using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyScript.Scene;

public class SpecterManager : MonoBehaviour
{
    [SerializeField] 
    private EnemySpawner _enemySpawner;
    [SerializeField] 
    private GameObject _enemyPref;

    [SerializeField]
    private int maxEnemyCount;
    
    [SerializeField] 
    private Main main;
    
    private int increaseNum;
    
    public void Init()
    {
        _enemySpawner.Init(maxEnemyCount, _enemyPref, new SpecterFactory());
        _enemySpawner.StartSpawn(1f);
        increaseNum = (int)main.battleLevel;
        StartCoroutine(IncreaseEnemySpawn());
    }

    IEnumerator IncreaseEnemySpawn()
    {
        while (true)
        {
            yield return new WaitForSeconds(30);
            _enemySpawner.IncreaseMaxCount(increaseNum);
        }
    }
}
