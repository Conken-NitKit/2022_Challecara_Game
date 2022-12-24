using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UniRx;

public class PlayerHPSlider : MonoBehaviour
{
    [SerializeField]
    private Slider playerHPSlider;

    [SerializeField]
    private Text nowHP;

    [SerializeField]
    private PlayerStatus playerStatus;

    private void Start()
    {
        playerHPSlider.maxValue = 100;
        playerHPSlider.value = 100;
        playerStatus.OnPlayerHpDisappear.Subscribe(playerHp =>
        {
            playerHPSlider.value = playerHp;
            nowHP.text = $"{playerHp: 000} / 100";
        });
    }
}
