using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

/// <summary>
/// シーン遷移のアニメーション
/// </summary>
public class SceneTransitionAnimation : MonoBehaviour
{
    [SerializeField] 
    private Image animationPanel;

    void Start()
    {
        OpenScene();
    }
    
    /// <summary>
    /// 遷移完了後のアニメーション
    /// </summary>
    private void OpenScene()
    {
        animationPanel.DOFade(0f, 0.5f).SetDelay(1);
    }

    /// <summary>
    /// 遷移する時のアニメーション
    /// </summary>
    public void CloseScene()
    {
        animationPanel.DOFade(1f, 0.5f);
    }
}
