using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuFlowManager : MonoBehaviour
{
    [SerializeField] private GameMenu gameMenuLoader;
    [SerializeField] private GameObject menuPanel;
    [SerializeField] private GameObject levelPanel;
    [SerializeField] private GameObject userDataPanel;
    [SerializeField] private Text nameWarningText;
    [SerializeField] private Text idWarningText;

    [SerializeField] private UserDataChecker userDataChecker;
    //[SerializeField] private 

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
        if (userDataChecker.IsAvailableUserName())
        {
            nameWarningText.text = "有効な名前が入力されていません！";
            return;
        }

        if (userDataChecker.IsAvailableChatId())
        {
            idWarningText.text = "有効なチャットIdが入力されていません！";
            return;
        }
        Debug.Log("いけます！多分");
        // ここにシーンロード処理
    }
    
}
