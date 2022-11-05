using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
