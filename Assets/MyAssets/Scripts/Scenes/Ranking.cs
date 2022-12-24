using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ranking : MonoBehaviour
{
    public void LoadGameMenu()
    {
         SceneLoader.Load<GameMenu>("GameMenu");
    }
}
