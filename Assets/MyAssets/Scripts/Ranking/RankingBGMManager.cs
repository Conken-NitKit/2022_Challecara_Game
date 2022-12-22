using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RankingBGMManager : MonoBehaviour
{
    [SerializeField]
    private AudioSource hoge;
    
    [SerializeField]
    private AudioSource hoge2;
    IEnumerator Start()
    {
        yield return new WaitForSeconds(2);
        hoge.Play();
        hoge2.Play();
    }
}
