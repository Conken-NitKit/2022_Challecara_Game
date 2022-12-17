using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestEnemy : Enemy
{
    private static EnemyParams param = null;
    public static EnemyParams Params => param ?? (param = Resources.Load<EnemyParams>("EnemyDatas/test"));
    protected float Hp;

    public override void Init()
    {
        Hp = Params.maxHp;
        gameObject.SetActive(true);
        Debug.Log("復活！ At.Init");
    }

    public override void Attack()
    {
        Debug.Log($"テスト！ At.Attack");
    }
    
    public override void AddedDamage(float damage)
    {
        Hp -= damage;
        Debug.Log($"{damage}痛いよ！ At.AddedDamage");
    }
    
    public override void Dead()
    {
        Debug.Log($"ぐえっ At.Dead");
        gameObject.SetActive(false);
    }
    
    
    private void OnEnable()
    {
        StartCoroutine(nameof(TestLoop));
    }

    private IEnumerator TestLoop()
    {
        while (true)
        {
            
            AddedDamage(3f);
            yield return new WaitForSeconds(1f);
            if (Hp <= 0)
            {
                Dead();
                yield break;
            }
        }
    } 

}
