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
    
    IEnumerator Start()
    {
        while (true)
        {
            yield return new WaitForSeconds(animationInterval);
            var instance = Instantiate(textsAnimation, new Vector3( 0.0f, 0.0f, 0.0f), Quaternion.identity);
            instance.transform.SetParent(gameObject.transform,false);
        }
    }
}
