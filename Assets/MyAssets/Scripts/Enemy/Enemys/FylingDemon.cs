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
    
    public override void Dead()
    {
        gameObject.SetActive(false);
    }
}
