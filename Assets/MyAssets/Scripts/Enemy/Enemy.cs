using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    protected static EnemyParams Params;
    protected float Hp;

    /// <summary>
    /// Enemyの攻撃処理
    /// </summary>
    public abstract void Attack();
    /// <summary>
    /// Enemyの被ダメージ処理
    /// </summary>
    /// <param name="damege">受けるダメージ</param>
    public abstract void AddedDamage(float damege);
    /// <summary>
    /// Enemyの死亡処理
    /// </summary>
    public abstract void Dead();
    /// <summary>
    /// Enemy初期化処理
    /// </summary>
    public abstract void Init();
}
