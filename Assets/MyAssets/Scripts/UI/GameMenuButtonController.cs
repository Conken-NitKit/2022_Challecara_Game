using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMenuButtonController : BaseButtonController
{
    [SerializeField] private MenuFlowManager menuFlowManager;

    protected override void OnButtonClick(string objectName)
    {
        switch (objectName)
        {
            case "ButtonLevelHard":
            case "ButtonLevelNormal":
            case "ButtonLevelEasy":
                ChoiceBattleLevel(objectName);
                break;
            case "ButtonGameStart":
                ChoiceGameStart();
                break;
            default:
                throw new System.Exception("Not implemented!!");
        }
    }

    protected override void OnButtonDown(string objectName)
    {
    }

    protected override void OnButtonUp(string objectName)
    {
    }

    private void ChoiceBattleLevel(string buttonName)
    {
        Debug.Log($"{buttonName}");
        menuFlowManager.ProceedUserDataInput();
    }

    private void DecideUserData()
    {
        
    }

    private void ChoiceGameStart()
    {
        menuFlowManager.ProceedLevelChoice();
    }
}