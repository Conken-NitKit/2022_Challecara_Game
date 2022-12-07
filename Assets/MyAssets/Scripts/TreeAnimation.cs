using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class TreeAnimation : MonoBehaviour
{
    void Start()
    {
        transform.DOShakePosition(100, 0.1f, 1, 0.1f, false, false).SetLoops(-1);
    }
}
