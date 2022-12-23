using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private EnemySpawner enemySpawner;
    public IReadOnlyReactiveProperty<int> Score => score;

    private readonly IntReactiveProperty score = new IntReactiveProperty(0);

    private void Start()
    {
        enemySpawner.OnEnemyCreated.Subscribe(enemy => {
            enemy.OnAddScore.Subscribe(addScore => score.Value += addScore);
        });
    }
}
