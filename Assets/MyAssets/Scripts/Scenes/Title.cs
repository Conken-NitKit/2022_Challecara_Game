using UnityEngine.SceneManagement;
using Cysharp.Threading.Tasks;
using UnityEngine;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace MyScript.Scene
{
    public class Title : MonoBehaviour
    {
        /// <summary>
        /// GameMenuをロードする関数
        /// </summary> 
        public void LoadGameMenu()
        {
            SceneLoader.Load<GameMenu>("GameMenu");
        }
    }
}
