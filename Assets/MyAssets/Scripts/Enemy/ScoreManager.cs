using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    //public IReadOnlyReactiveProperty<int> Score => score;

    //private readonly IntReactiveProperty score = new IntReactiveProperty(0);

    public int score { get; private set; }

    void Start()
    {
        score = 0;
    }
    
    public void AddScore(int increaseNum)
    {
        score += increaseNum;
        Debug.Log($"SCORE{score}");
    }
}
