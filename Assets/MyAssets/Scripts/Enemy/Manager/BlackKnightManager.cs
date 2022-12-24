using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackKnightManager : MonoBehaviour
{
    [SerializeField] 
    private EnemySpawner _enemySpawner;
    [SerializeField] 
    private GameObject _enemyPref;

    [SerializeField]
    private int maxEnemyCount;
    
    private int increaseNum;
    
    public void Init()
    {
        _enemySpawner.Init(maxEnemyCount, _enemyPref, new BlackKnightFactory());
        _enemySpawner.StartSpawn(1f);
        increaseNum = 1;
        StartCoroutine(IncreaseEnemySpawn());
    }

    IEnumerator IncreaseEnemySpawn()
    {
        while (true)
        {
            yield return new WaitForSeconds(60);
            _enemySpawner.IncreaseMaxCount(increaseNum);
        }
    }
}
