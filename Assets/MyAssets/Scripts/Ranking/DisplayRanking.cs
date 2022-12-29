using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using PlayFab;
using PlayFab.ClientModels;

public class DisplayRanking : MonoBehaviour
{
    [SerializeField]
    private List<Text> rankingNameTexts = default;
    [SerializeField]
    private List<Text> rankingScoreTexts = default;

    [SerializeField]
    private BattleLevel.BattleLevels levels;

    void Start()
    {
        RankingUserLogin();
    }

    public void GetLeaderboard() { 
        var request = new GetLeaderboardRequest{
            StatisticName   = $"{levels}",
            StartPosition   = 0,
            MaxResultsCount = 3
        };

        Debug.Log($"ランキング(リーダーボード)の取得開始");
        PlayFabClientAPI.GetLeaderboard(request, OnGetLeaderboardSuccess, OnGetLeaderboardFailure);
    }
  
    private void OnGetLeaderboardSuccess(GetLeaderboardResult result){
        Debug.Log($"ランキング(リーダーボード)の取得に成功しました");

        var i = 0;
        
        foreach (var entry in result.Leaderboard) {
            Debug.Log($"名前 : {entry.DisplayName} スコア : {entry.StatValue}");
            rankingNameTexts[i].text = $"{entry.DisplayName}";
            rankingScoreTexts[i].text = $"{entry.StatValue}";
            i++;
        }
    }

    private void OnGetLeaderboardFailure(PlayFabError error){
        Debug.LogError($"ランキング(リーダーボード)の取得に失敗しました\n{error.GenerateErrorReport()}");
    }
    public void RankingUserLogin()
    {
        PlayFabClientAPI.LoginWithCustomID(
            new LoginWithCustomIDRequest { CustomId = "ranker", CreateAccount = true},
            result => 
            {
                Debug.Log("ログイン成功！");
                GetLeaderboard();
            },
            error => 
            {
                Debug.Log("ログイン失敗");
            }
        );
    }
}
