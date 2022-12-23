using System;
using UnityEngine;
using UniRx;

public abstract class Enemy : MonoBehaviour
{
    protected static EnemyParams Params;
    protected float Hp;
    private Subject<int> addScore = new Subject<int>(); 
    public IObservable<int> OnAddScore
    {
        get { return addScore; }
    } 
    
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
    /// <summary>
    /// スコアを増加する処理
    /// </summary>

    protected void AddScore(int score)
    {
        addScore.OnNext(score);
    }
}
