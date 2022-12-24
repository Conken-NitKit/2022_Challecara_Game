using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMenuButtonController : BaseButtonController
{
    
    protected override void OnButtonClick(string objectName)
    {
        switch (objectName)
        {
            case "ButtonLevelHard":
            case "ButtonLevelNormal":
            case "ButtonLevelEasy":
                BattleLevelChoice(objectName);
                break;
            case "ButtonUserDataDecide":
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

    private void BattleLevelChoice(string buttonName)
    {
        Debug.Log($"{buttonName}");
    }

    private void UserDataDecide()
    {
       
    }
}
