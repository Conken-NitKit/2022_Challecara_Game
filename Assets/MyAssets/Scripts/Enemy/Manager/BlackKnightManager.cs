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
    
    void Start()
    {
        _enemySpawner.Init(maxEnemyCount, _enemyPref, new BlackKnightFactory());
        _enemySpawner.StartSpawn(1f);
        increaseNum = 2;
    }
}
