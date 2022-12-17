using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static System.Exception;

public abstract class EnemyFactory
{
    /// <summary>
    /// 受け取ったObjectにFactoryと対応するコンポーネントを付けて返すメソッド
    /// </summary>
    /// <param name="obj">敵コンポーネントをつけるobject</param>
    /// <returns>対応するコンポーネントが付与されたobject</returns>
    public GameObject Create(GameObject obj)
    {
            GameObject enemy = AddEnemyComponent(obj);
            RegisterEnemy(enemy.GetComponent<Enemy>());
            return enemy;
    }
    /// <summary>
    /// Factoryが生成したインスタンスのリストを取得するメソッド
    /// </summary>
    /// <returns>Factoryが生成したインスタンスのArrayList</returns>
    public abstract ArrayList GetEnemys();
    
    protected abstract GameObject AddEnemyComponent(GameObject obj);
    protected abstract void RegisterEnemy(Enemy enemy);
}
