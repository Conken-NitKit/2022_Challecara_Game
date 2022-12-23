using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UnityEngine.SocialPlatforms.Impl;

public class TestScript : MonoBehaviour
{
    [SerializeField] private EnemySpawner _testSpawner;
    [SerializeField] private GameObject _testPref;
    [SerializeField] private ScoreManager _scoreManager;
    private float time = 10;
    private int increaseNum = 2;
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
            Debug.Log($"敵を{increaseNum}匹増やすよ！");
            _testSpawner.IncreaseMaxCount(increaseNum);
            time = 10;
        }
        _scoreManager.Score
            .Subscribe(x =>
            {
                Debug.Log(x);
            }).AddTo(this);
        ;
    }
}
