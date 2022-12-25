using PlayFab;
using PlayFab.ClientModels;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RankingManager : MonoBehaviour
{
    BattleLevel.BattleLevels battleLevel;

    public void UserLogin(string usename,int score, BattleLevel.BattleLevels battleLevel)
    {
        this.battleLevel = battleLevel;
        PlayFabClientAPI.LoginWithCustomID
        (
            new LoginWithCustomIDRequest {CustomId = usename, CreateAccount = true},
            result =>
            {
                Debug.Log("ログイン成功！");
                SetPlayerDisplayName(usename,score);
            },
            error =>
            {
                Debug.Log("ログイン失敗...");
            }
        );
    }

    private void SendStatisticUpdate (int score) 
    {
        string rankingName = null;
        switch(battleLevel)
        {
            case BattleLevel.BattleLevels.Easy:
                rankingName = "Easy";
                break;
            case BattleLevel.BattleLevels.Normal:
                rankingName = "Normal";
                break;
            case BattleLevel.BattleLevels.Hard:
                rankingName = "Hard";
                break;
        }
        Debug.Log(rankingName);
        // 送信したい更新情報
        var statisticUpdate = new StatisticUpdate
        {
            StatisticName = rankingName,
            Value = score,
        };
        var request = new UpdatePlayerStatisticsRequest
        {
            Statistics = new List<StatisticUpdate>
            {
                statisticUpdate
            }
        };

        PlayFabClientAPI.UpdatePlayerStatistics(request, OnSuccess, OnError);

        void OnSuccess(UpdatePlayerStatisticsResult result)
        {
            Debug.Log("Send score was succeeded.");
        }
        void OnError(PlayFabError error)
        {
            Debug.Log($"{error.Error}");
        }
    }
    private void SetPlayerDisplayName(string displayName,int score)
    {
        var request = new UpdateUserTitleDisplayNameRequest
        {
            DisplayName = displayName
        };
        PlayFabClientAPI.UpdateUserTitleDisplayName(request, OnSuccess, OnError);
        void OnSuccess(UpdateUserTitleDisplayNameResult result)
        {
            Debug.Log("表示名決定！");
            SendStatisticUpdate (score);
        }
        void OnError(PlayFabError error)
        {
            Debug.Log($"{error.Error}");
        }
    }
}
