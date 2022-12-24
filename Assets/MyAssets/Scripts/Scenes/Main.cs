using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;
using UnityEngine.UI;

namespace MyScript.Scene
{
    public class Main : MonoBehaviour
    {
        [SerializeField] private Text playerName;

        private BattleLevel.BattleLevels battleLevel;

        public void SetArguments(string liveURL, BattleLevel.BattleLevels battleLevel, string playerName)
        {
            this.playerName.text = playerName;
            this.battleLevel = battleLevel;
        }

        public async Task PassMainToResult(int killCount, double timeSurvived)
        {
            var result = await SceneLoader.Load<Result>("Result");
            result.SetArguments(killCount, timeSurvived, playerName.text, battleLevel);
        }
    }
}
