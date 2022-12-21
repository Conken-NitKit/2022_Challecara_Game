using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Result : MonoBehaviour
{
    public void SetArguments(int numberofkill,double timesurvived)
    {
        Debug.Log("ok");
    }
    /// <summary>
    /// Rankingをロードする関数
    /// </summary>
    public void LoadRanking()
    {
        SceneLoader.Load<Ranking>("Ranking");
    }
    public void LoadGameMenu()
    {
        SceneLoader.Load<GameMenu>("GameMenu");
    }
}
