using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// プレイヤーのステータス管理クラス
/// </summary>
public class PlayerStatus : MonoBehaviour
{
    private const float DefaultPlayerHp = 100.0f;
    
    private float playerHp;
    
    private const float DefaultPlayerAtk = 1.0f;

    private float nowPlayerAtk;

    private bool runDoubleAtk;

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
    private void IncreaseHp(float recoveryAmount)
    {
        playerHp += recoveryAmount;
    }

    /// <summary>
    /// プレイヤーのHPを減らすメソッド
    /// 主に敵の攻撃から減らす
    /// </summary>
    /// <param name="damageTaken">受けたダメージ量</param>
    private void DecreaseHp(float damageTaken)
    {
        playerHp -= damageTaken;
    }

    /// <summary>
    /// 攻撃力にバフをかけるメソッド
    /// 受け取った値を攻撃力に掛ける
    /// </summary>
    /// <param name="buff">攻撃の倍率</param>
    private IEnumerator DoubleAtk(float buff)
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

}
