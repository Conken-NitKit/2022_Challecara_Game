using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using MyScript.Scene;
public class Result : MonoBehaviour
{ 
    [SerializeField] private RankingManager rankingManager;

    private int totalScore;

    private string playerName = "林";

    [SerializeField]
    private Text numberKillText;
    [SerializeField]
    private Text timeSurvivedText;

    [SerializeField]
    private Text totalScoreText;

    public void SetArguments(int numberKill, double timeSurvived)
    {
        
        numberKillText.text = $"{numberKill:000}";
        timeSurvivedText.text = $"{(int)(timeSurvived/60):00}:{(int)(timeSurvived%60):00}";
        totalScore = (int)(numberKill * timeSurvived);
        totalScoreText.text = $"{totalScore}";
        rankingManager.UserLogin(playerName, totalScore);
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
