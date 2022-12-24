using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using MyScript.Scene;

public class MenuFlowManager : MonoBehaviour
{
    [SerializeField] private GameMenu gameMenuLoader;
    [SerializeField] private GameObject menuPanel;
    [SerializeField] private GameObject levelPanel;
    [SerializeField] private GameObject userDataPanel;
    [SerializeField] private Text nameWarningText;
    [SerializeField] private Text idWarningText;

    [SerializeField] private UserDataChecker userDataChecker;
    [SerializeField] private GameMenu gameMenu;

    public void ProceedLevelChoice()
    {
        if(menuPanel != null)menuPanel.SetActive(false);
        if(levelPanel != null)levelPanel.SetActive(true);
    }

    public void ProceedUserDataInput()
    {
        if(levelPanel != null)levelPanel.SetActive(true);
        if(userDataPanel != null)userDataPanel.SetActive(true);
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

        gameMenu.PassGameMenutoMain();
    }
    
}
