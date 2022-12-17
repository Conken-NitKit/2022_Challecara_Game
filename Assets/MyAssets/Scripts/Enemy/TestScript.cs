using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScript : MonoBehaviour
{
    [SerializeField] private EnemySpawner _testSpawner;
    [SerializeField] private GameObject _testPref;
    void Start()
    {
        _testSpawner.enemyFactory = new TestFactory();
        _testSpawner.Init(10,_testPref);
        _testSpawner.StartSpawn(1f);
    }
}
