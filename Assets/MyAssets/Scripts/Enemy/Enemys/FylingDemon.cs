using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FylingDemon : Enemy
{
    private static EnemyParams param = null;
    private static EnemyParams Params => param ?? (param = Resources.Load<EnemyParams>("EnemyDatas/FylingDemon"));

    [SerializeField]
    private GameObject attackRange;
    
    public override void Init()
    {
        Hp = Params.maxHp;
        gameObject.SetActive(true);
        Debug.Log("復活！ At.Init");
    }

    public override void Attack()
    {
        Debug.Log($"テスト！ At.Attack");
        attackRange.SetActive(true);
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
}
