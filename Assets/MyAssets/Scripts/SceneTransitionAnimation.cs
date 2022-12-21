using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class SceneTransitionAnimation : MonoBehaviour
{
    [SerializeField] 
    private Image animationPanel;

    void Start()
    {
        OpenScene();
    }
    
    public void OpenScene()
    {
        animationPanel.DOFade(0f, 0.5f).SetDelay(1);
    }

    public void CloseScene()
    {
        animationPanel.DOFade(1f, 0.5f);
    }
}
