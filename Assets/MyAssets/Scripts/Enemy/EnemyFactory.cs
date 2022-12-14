using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static System.Exception;

public abstract class EnemyFactory
{
    public Enemy Create()
    {
            Enemy enemy = CreateEnemy();
            RegisterEnemy(enemy);
            return enemy;
    }
    protected abstract Enemy CreateEnemy();
    protected abstract void RegisterEnemy(Enemy enemy);
    public abstract ArrayList GetEnemys();
}
