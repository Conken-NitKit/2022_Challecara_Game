using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UniRx;

/// <summary>
/// タイマークラスです
/// </summary>
public class Timer : MonoBehaviour
{
    public ReactiveProperty<float> nowTimer { get; private set; } = new ReactiveProperty<float>();
    
    [SerializeField]
    private Text timerText;

    [SerializeField] 
    private PlayerStatus playerStatus;
    
    private bool isDie;
    
    /// <summary>
    /// 外から呼び出しできるように
    /// カウントダウンとかで始まる感じにするかぁっていうのの名残です
    /// </summary>
    public void StartCountUp()
    {
        nowTimer.Value = 0f;

        isDie = false;
        
        var subscription = nowTimer.Subscribe(x =>
        {
            timerText.text = $"{(int)(nowTimer.Value) / 60 :00} : {nowTimer.Value % 60 :00}";
        });
        
        playerStatus.OnPlayerHpDisappear.Subscribe(playerHp =>
        {
            if(playerHp <= 0)
            {
                isDie = true;
            }
        });
        StartCoroutine(CountUpTime());
    }

    /// <summary>
    /// プレイヤーが死なない限りはカウントアップし続ける処理
    /// </summary>
    private IEnumerator CountUpTime()
    {
        while (!isDie)
        {
            yield return new WaitForSeconds(0.1f);
            nowTimer.Value += 0.1f;
        }
    }
}
