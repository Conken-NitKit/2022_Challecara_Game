using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RatAssassinManager : MonoBehaviour
{
    [SerializeField] 
    private EnemySpawner _enemySpawner;
    [SerializeField] 
    private GameObject _enemyPref;
    [SerializeField] 
    private ScoreManager _scoreManager;

    [SerializeField]
    private int maxEnemyCount;
    
    private int increaseNum;
    
    void Start()
    {
        _enemySpawner.Init(maxEnemyCount, _enemyPref, new RatAssassinFactory());
        _enemySpawner.StartSpawn(1f);
        increaseNum = 2;
    }
}
