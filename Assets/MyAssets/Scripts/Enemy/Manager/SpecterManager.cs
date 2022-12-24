using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecterManager : MonoBehaviour
{
    [SerializeField] 
    private EnemySpawner _enemySpawner;
    [SerializeField] 
    private GameObject _enemyPref;
    [SerializeField] 
    private ScoreManager _scoreManager;
    [SerializeField] 
    private EnemyFactory _enemyFactory;

    [SerializeField]
    private int maxEnemyCount;
    
    private int increaseNum;
    
    void Start()
    {
        _enemySpawner.Init(maxEnemyCount, _enemyPref,new SpecterFactory());
        _enemySpawner.StartSpawn(1f);
        increaseNum = 2;
    }
}
