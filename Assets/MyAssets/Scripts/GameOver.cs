using System;
using System.Collections;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UniRx;
using DG.Tweening;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    [SerializeField] private PlayerStatus playerStatus;
    [SerializeField] private Text gameOverText;
    [SerializeField] private Image gameOverPanel;
    [SerializeField] private Image meteo;
    [SerializeField] private Image gameOverButton;
    [SerializeField] private Text buttonText;
    [SerializeField] private SceneTransitionAnimation sceneTransitionAnimation;

    [SerializeField] private float tweenTime_Text;//Textのトゥイーン時間
    [SerializeField] private float tweenTime_meteo;//meteoのトゥイーン時間
    [SerializeField] private float endvalue_Panel;//変化させるアルファの値(Panel)
    [SerializeField] private float duration_Panel;//フェードさせる時間(Panel)
    [SerializeField] private float endvalue_Button;//変化させるアルファの値(Button)
    [SerializeField] private float duration_Button;//フェードさせる時間(Button)
    [SerializeField] private float Posx;//隕石の最終的なx座標
    [SerializeField] private float Posy;//隕石の最終的なy座標
    
    [SerializeField]
    private ScoreManager scoreManager;

    [SerializeField]
    private Timer timer;

    /// <summary>
    /// クリックしたらResultシーンへ遷移
    /// </summary>
    public async void OnClick()
    {
        sceneTransitionAnimation.CloseScene();
        await UniTask.Delay(TimeSpan.FromSeconds(1f));
        var result = await SceneLoader.Load<Result>("Result");
        result.SetArguments(scoreManager.score, timer.nowTimer.Value);
    }

    /// <summary>
    /// プレイヤーが死んだらゲームオーバーアニメーションを開始するメソッド
    /// </summary>
    void Start()
    {
        playerStatus.OnPlayerHpDisappear.Subscribe(playerHp =>
        {
            if(playerHp <= 0)
            {
                var sequence = DOTween.Sequence()
                    .Append(gameOverPanel.DOFade(endvalue_Panel, duration_Panel))
                    .Join(gameOverText.DOText("Game over...", tweenTime_Text).SetEase(Ease.Linear))
                    .Join(meteo.rectTransform.DOLocalMove(new Vector3(Posx, Posy, 0f), tweenTime_meteo)
                        .SetEase(Ease.InCubic))
                    .Join(gameOverButton.DOFade(endvalue_Button, duration_Button))
                    .Join(buttonText.DOText("→Result", tweenTime_Text).SetEase(Ease.Linear));
                sequence.Play();
            }
        });
    }
}
