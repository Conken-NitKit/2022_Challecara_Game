using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace MyScript.Scene
{
    public class GameMenu : MonoBehaviour
    {
        [SerializeField] private InputField chatIdInputField;
        [SerializeField] private InputField nameInputField;

        [SerializeField] private GameMenuButtonController gameMenuButtonController;

        public async Task PassGameMenutoMain()
        {
            var main = await SceneLoader.Load<Main>("Main");
            main.SetArguments(chatIdInputField.text, gameMenuButtonController.battleLevel, nameInputField.text);
        }

        public void LoadTitle()
        {
            SceneLoader.Load<Title>("Title");
        }

        public void LoadMain()
        {
            PassGameMenutoMain();
        }

        public void LoadRanking()
        {
            SceneLoader.Load<Ranking>("Ranking");
        }
    }
}
