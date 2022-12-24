using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beholder : Enemy
{
    private static EnemyParams param = null;
    private static EnemyParams Params => param ?? (param = Resources.Load<EnemyParams>("EnemyDatas/Beholder"));

    [SerializeField]
    private GameObject attackRange;
    
    public override void Init()
    {
        Hp = Params.maxHp;
        Debug.Log("Beholder");
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
