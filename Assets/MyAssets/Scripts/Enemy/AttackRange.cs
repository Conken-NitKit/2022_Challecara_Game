using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;

public class AttackRange : MonoBehaviour
{
    private bool isAttack = false;
    private float seconds = 0.1f;
    
    private void OnTriggerEnter(Collider collider)
    {
        if (isAttack)
        {
            Debug.Log(collider.name);
            collider.gameObject.GetComponent<PlayerStatus>().DecreaseHp(5.0f);
        }
    }

    private async UniTask OnEnable()
    {
        isAttack = true;
        await UniTask.Delay(TimeSpan.FromSeconds(seconds));
        this.gameObject.SetActive(false);
    }
}
