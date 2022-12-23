using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private EnemySpawner enemySpawner;
    public int Score { get; set; }

    private void Start()
    {
        enemySpawner.OnEnemyCreated.Subscribe(enemy => {
            enemy.OnAddScore.Subscribe(addScore => Score += addScore);
        });
    }
}
