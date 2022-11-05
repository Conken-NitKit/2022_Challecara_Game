using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class TitleTextAnimation : MonoBehaviour
{

    [SerializeField]
    private float animationSeconds = 1f;
    
    [SerializeField]
    private float animationScaleX = 1.2f;

    [SerializeField]
    private float animationScaleY = 1.01f;

    private float transmittance = 0f;
    
    private void Start()
    {
        if (this.gameObject.GetComponent<Text>() != null)
        {
            Text gameObjectText = this.gameObject.GetComponent<Text>();
            var textAnimationSequence = DOTween.Sequence()
                .Append(gameObjectText.rectTransform.DOScaleX(animationScaleX, animationSeconds))
                .Join(gameObjectText.rectTransform.DOScaleY(animationScaleY, animationSeconds))
                .Join(gameObjectText.DOFade(transmittance, animationSeconds))
                .AppendCallback(() => Destroy(this.gameObject));
            textAnimationSequence.Play();
        }
        else
        {
            Image gameObjectImage = this.gameObject.GetComponent<Image>();
            var textAnimationSequence = DOTween.Sequence()
                .Append(gameObjectImage.rectTransform.DOScaleX(animationScaleX, animationSeconds))
                .Join(gameObjectImage.rectTransform.DOScaleY(animationScaleY, animationSeconds))
                .Join(gameObjectImage.DOFade(transmittance, animationSeconds))
                .AppendCallback(() => Destroy(this.gameObject));
            textAnimationSequence.Play();
        }
    }
}
