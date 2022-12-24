using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;
using System;
using UnityEngine.UI;
using DG.Tweening;

/// <summary>
///タイトルの隕石にアニメーションをさせるクラス
/// </summary>


public class TitleLogoMove : MonoBehaviour
{
    [SerializeField] private Image meteo;

    [SerializeField] private float Tweentime;//その動きをする時間
    [SerializeField] private float Scaletimes;//何倍にするか
    [SerializeField] private float Posx;//移動先のx座標
    [SerializeField] private float Posy;//移動先のy座標

    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip meteoBGM;
    [SerializeField] private SceneTransitionAnimation transitionAnimation;
    [SerializeField] private Title title;
    private float seconds = 1f;
    private float Shakepower = 50;//揺れの強さ
    private int Frequency = 50;//振動数
    private float Camerashake = 50;//手ブレ

    public void OnClicked() 
    {
        var sequence = DOTween.Sequence()
            .Append(meteo.rectTransform.DOLocalMove(new Vector3(Posx, Posy, 0f), Tweentime).SetEase(Ease.InCubic))
            .Join(meteo.rectTransform.DOScale(Vector3.one * Scaletimes, Tweentime).SetEase(Ease.InQuint))
            .Join(meteo.rectTransform.DOShakeRotation(Tweentime, Shakepower, Frequency, Camerashake, true))
            .AppendCallback(() =>
            {
                LoadScene();
            }).OnStart(() =>
            {
                audioSource.clip = meteoBGM;
                audioSource.Play();
            });
        sequence.Play();
    }

    private async void LoadScene()
    {
        transitionAnimation.CloseScene();
        await UniTask.Delay(TimeSpan.FromSeconds(seconds));
        title.LoadGameMenu();
    }
}
