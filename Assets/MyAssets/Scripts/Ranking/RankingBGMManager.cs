using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 書き換えたい
/// シーン遷移アニメーション終了時に実行されるみたいな感じだけどメソッド渡せる場所作ってあげたらいいかなぁ
/// </summary>
public class RankingBGMManager : MonoBehaviour
{
    [SerializeField]
    private AudioSource rankingBGM;
    
    [SerializeField]
    private AudioSource speakingVoice;
    
    IEnumerator Start()
    {
        yield return new WaitForSeconds(2);
        rankingBGM.Play();
        speakingVoice.Play();
    }
}
