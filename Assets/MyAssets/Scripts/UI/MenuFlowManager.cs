using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuFlowManager : MonoBehaviour
{
    [SerializeField] private GameMenu gameMenuLoader;
    [SerializeField] private GameObject menuPanel;
    [SerializeField] private GameObject levelPanel;
    [SerializeField] private GameObject userDataPanel;

    public void ProceedLevelChoice()
    {
        menuPanel.SetActive(false);
        levelPanel.SetActive(true);
    }

    public void ProceedUserDataInput()
    {
        levelPanel.SetActive(false);
        userDataPanel.SetActive(true);
    }
    public void ProceedMainGame()
    {
        levelPanel.SetActive(false);
        userDataPanel.SetActive(true);
        // ここにシーンロード処理
    }
    
}
