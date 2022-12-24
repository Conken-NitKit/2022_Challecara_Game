using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyScript.Scene
{
    public class Ranking : MonoBehaviour
    {
        public void LoadGameMenu()
        {
            SceneLoader.Load<GameMenu>("GameMenu");
        }
    }
}
