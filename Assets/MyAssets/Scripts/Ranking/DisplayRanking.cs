using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using PlayFab;
using PlayFab.ClientModels;

/// <summary>
/// ランキング表示させる処理のクラス
/// </summary>
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

    /// <summary>
    /// ランキング取得するメソッド
    /// StatisticName : ランキングの名前。ログインしてるアカウントから取得したいランキングの名前引っ張ってきて代入する（今回のは複数あるのでenumで管理）
    /// StartPosition : ランキング取得し始めるポジション。0オリジン
    /// MaxResultsCount : 取得するランキングの個数。
    /// StartPosition = 0、MaxResultsCount = 3だと1位から3位までのランキングを取得する
    /// </summary>
    public void GetLeaderboard() { 
        var request = new GetLeaderboardRequest{
            StatisticName   = $"{levels}",
            StartPosition   = 0,
            MaxResultsCount = 3
        };

        PlayFabClientAPI.GetLeaderboard(request, OnGetLeaderboardSuccess, OnGetLeaderboardFailure);
    }
  
    /// <summary>
    /// ランキング取得成功時処理
    /// 今回は名前とスコアをそれぞれ取得してテキストに入れてます
    /// </summary>
    /// <param name="result">取得できたランキングの情報</param>
    private void OnGetLeaderboardSuccess(GetLeaderboardResult result){

        var i = 0;
        
        foreach (var entry in result.Leaderboard) {
            Debug.Log($"名前 : {entry.DisplayName} スコア : {entry.StatValue}");
            rankingNameTexts[i].text = $"{entry.DisplayName}";
            rankingScoreTexts[i].text = $"{entry.StatValue}";
            i++;
        }
    }

    /// <summary>
    /// ランキング取得失敗時処理
    /// </summary>
    /// <param name="error">エラー内容</param>
    private void OnGetLeaderboardFailure(PlayFabError error){
        Debug.LogError($"ランキング(リーダーボード)の取得に失敗しました\n{error.GenerateErrorReport()}");
    }
    
    /// <summary>
    /// ランキング取得する時にログインが必要なのでそれ用の処理
    /// </summary>
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
