using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

/// <summary>
///タイトルの隕石にアニメーションをさせるクラス
///座標はこの値がちょうど良いので一旦このままにしておきます
/// </summary>


public class TitleLogoMove : MonoBehaviour
{
    [SerializeField] private Image meteo;

    [SerializeField] private float Tweentime;//その動きをする時間
    [SerializeField] private float Shakepower;//揺れの強さ
    [SerializeField] private int Frequency;//振動数
    [SerializeField] private float Camerashake;//手ブレ
    [SerializeField] private float Scaletimes;//何倍にするか
    [SerializeField] private float Posx;//移動先のx座標
    [SerializeField] private float Posy;//移動先のy座標

    void Update () 
    {
        if (Input.GetMouseButtonDown(0))
        {
            var sequence = DOTween.Sequence()
                .Append(meteo.rectTransform.DOLocalMove(new Vector3(Posx, Posy, 0f), Tweentime).SetEase(Ease.InCubic))
                .Join(meteo.rectTransform.DOScale(Vector3.one * Scaletimes, Tweentime).SetEase(Ease.InSine))
                .Join(meteo.rectTransform.DOShakeRotation(Tweentime, Shakepower, Frequency, Camerashake, true))
                .AppendCallback(() => Debug.Log("end."));
            sequence.Play();
        }
   }
}
