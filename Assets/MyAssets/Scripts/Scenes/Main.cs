using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;
using UnityEngine.UI;

public class Main : MonoBehaviour
{
    [SerializeField] private Text playerName;

    public void SetArguments(string liveURL,string battleLevel, string playerName)
    {
        this.playerName.text = playerName;
    }
    
    public async Task PassMainToResult(int killCount,double timeSurvived)
    {
        var result = await SceneLoader.Load<Result>("Result");
        result.SetArguments(killCount, timeSurvived, playerName.text);
    }
}
