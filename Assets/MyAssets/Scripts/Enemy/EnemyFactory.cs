using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static System.Exception;

public abstract class EnemyFactory
{
    public GameObject Create(GameObject obj)
    {
            GameObject enemy = CreateEnemy(obj);
            RegisterEnemy(enemy.GetComponent<Enemy>());
            return enemy;
    }
    public abstract ArrayList GetEnemys();
    
    protected abstract GameObject CreateEnemy(GameObject obj);
    protected abstract void RegisterEnemy(Enemy enemy);
}
