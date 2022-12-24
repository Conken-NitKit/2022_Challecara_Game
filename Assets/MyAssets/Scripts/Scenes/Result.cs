using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Result : MonoBehaviour
{ 
    [SerializeField] private RankingManager rankingManager;

    private string playerName;

    public void SetArguments(int numberofkill, double timesurvived)
    {
        rankingManager.UserLogin(playerName, (int)(numberofkill * timesurvived));
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
