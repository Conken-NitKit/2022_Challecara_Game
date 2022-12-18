using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScript : MonoBehaviour
{
    [SerializeField] private EnemySpawner _testSpawner;
    [SerializeField] private GameObject _testPref;
    private float time = 10;
    private int increaseNum = 5;
    void Start()
    {
        _testSpawner.Init(10, _testPref,new TestFactory());
        _testSpawner.StartSpawn(1f);
    }

    private void Update()
    {
        time -= Time.deltaTime;
        if (　time < 0f )
        {
            Debug.Log($"敵を{increaseNum}増やすよ！");
            _testSpawner.IncreaseMaxCount(increaseNum);
            time = 10;
        }
    }
}