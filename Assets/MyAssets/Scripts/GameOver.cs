using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class GameOver : MonoBehaviour
{
    [SerializeField] private PlayerStatus playerStatus;

    void Start()
    {
        playerStatus.OnPlayerHpDisappear.Subscribe(playerHp =>
        {
            if(playerHp <= 0)
            {
                Debug.Log("GameOver");
            }
        });
    }
}
