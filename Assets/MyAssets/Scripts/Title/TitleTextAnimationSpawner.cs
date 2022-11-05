using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// アニメーションさせるオブジェクトを繰り返し生成するクラス
/// </summary>
public class TitleTextAnimationSpawner : MonoBehaviour
{
    [SerializeField] 
    private GameObject textsAnimation;

    [SerializeField]
    private float animationInterval = 5f;

    [SerializeField]
    private string canvasTagName = "Canvas";

    IEnumerator Start()
    {
        GameObject canvas = GameObject.FindWithTag(canvasTagName);
        while (true)
        {
            var instance = Instantiate(textsAnimation);
            instance.transform.SetParent(canvas.transform,false);

            yield return new WaitForSeconds(animationInterval);
        }
    }
}
