using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

/// <summary>
/// 木のユッサユッサする感じのアニメーション
/// こういう1行だけのアニメーション処理とかうまいことできないものか
/// </summary>
public class TreeAnimation : MonoBehaviour
{
    void Start()
    {
        transform.DOShakePosition(100, 0.1f, 1, 0.1f, false, false).SetLoops(-1);
    }
}
