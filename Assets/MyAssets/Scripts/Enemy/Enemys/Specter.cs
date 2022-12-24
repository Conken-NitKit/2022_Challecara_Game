using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;
using System;

public class Specter : Enemy
{
    private static EnemyParams param = null;
    private static EnemyParams Params => param ?? (param = Resources.Load<EnemyParams>("EnemyDatas/Specter"));

    [SerializeField]
    private GameObject attackRange;
    
    private ScoreManager scoreManager;
    
    private float seconds = 0.3f;

    private void Start()
    {
        scoreManager = GameObject.FindWithTag("Manager").GetComponent<ScoreManager>();
    }

    public override void Init()
    {
        Hp = Params.maxHp;
        gameObject.SetActive(true);
    }

    public override void Attack()
    {
        attackRange.SetActive(true);
    }
    
    public override void AddedDamage(float damage)
    {
        Hp -= damage;

        if (Hp < 0)
        {
            Dead();
        }
    }
    
    public override async void Dead()
    {
        scoreManager.AddScore(1);
        await UniTask.Delay(TimeSpan.FromSeconds(seconds));
        gameObject.SetActive(false);
    }
}
