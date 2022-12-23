using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;

public class AttackRange : MonoBehaviour
{
    private bool isAttack = false;
    private float seconds = 0.1f;
    
    private static EnemyParams param = null;

    [SerializeField]
    private string enemyName;

    private PlayerStatus playerStatus;

    void Start()
    {
        param = Resources.Load<EnemyParams>($"EnemyDatas/{enemyName}");
        playerStatus = GameObject.FindWithTag("Player").GetComponent<PlayerStatus>();
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (isAttack)
        {
            playerStatus.DecreaseHp(param.atk);
        }
    }

    private async UniTask OnEnable()
    {
        isAttack = true;
        await UniTask.Delay(TimeSpan.FromSeconds(seconds));
        this.gameObject.SetActive(false);
    }
}
