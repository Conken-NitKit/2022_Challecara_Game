using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

/// <summary>
/// プレイヤーのステータス管理クラス
/// </summary>
public class PlayerStatus : MonoBehaviour
{
    public const float DefaultPlayerHp = 100.0f;
    
    private float playerHp;
    
    private const float DefaultPlayerAtk = 1.0f;

    private float nowPlayerAtk;

    private bool runDoubleAtk;

    private Subject<float> GameOverSubject = new Subject<float>();

    public IObservable<float> OnPlayerHpDisappear
    {
        get { return GameOverSubject; }
    } 

    private void Awake()
    {
        nowPlayerAtk = DefaultPlayerAtk;

        playerHp = DefaultPlayerHp;
    }


    /// <summary>
    /// プレイヤーのHPを増やすメソッド
    /// 主に回復で使用する
    /// </summary>
    /// <param name="recoveryAmount">回復量</param>
    public void IncreaseHp(float recoveryAmount)
    {
        playerHp += recoveryAmount;

        GameOverSubject.OnNext(playerHp);
    }

    /// <summary>
    /// プレイヤーのHPを減らすメソッド
    /// 主に敵の攻撃から減らす
    /// </summary>
    /// <param name="damageTaken">受けたダメージ量</param>
    public void DecreaseHp(float damageTaken)
    {
        playerHp -= damageTaken;

        GameOverSubject.OnNext(playerHp);
    }

    /// <summary>
    /// 攻撃力にバフをかけるメソッド
    /// 受け取った値を攻撃力に掛ける
    /// </summary>
    /// <param name="buff">攻撃の倍率</param>
    public IEnumerator DoubleAtk(float buff)
    {
        if (runDoubleAtk)
        {
            yield break;
        }

        runDoubleAtk = true;
        nowPlayerAtk *= buff;

        yield return new WaitForSeconds(5.0f);
        
        nowPlayerAtk = DefaultPlayerAtk;
        runDoubleAtk = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            DecreaseHp(10);
        }
    }
}
