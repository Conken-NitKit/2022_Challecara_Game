using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testdazeiei : MonoBehaviour
{
    [SerializeField] private EnemySpawner _testSpawner;
    [SerializeField] private GameObject _testPref;
    // Start is called before the first frame update
    void Start()
    {
        _testSpawner.enemyFactory = new TestFactory();
        _testSpawner.MaxEnemyCount = 10;
        _testSpawner.prefab = _testPref;
        _testSpawner.Init();
        _testSpawner.StartSpawn(1f);
    }
}
