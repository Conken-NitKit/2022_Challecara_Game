using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestEnemy : Enemy
{ 
    public override float Hp { get; set; }
    public override float AttackPoint { get; set; }
    public override float Velocity { get; set; }
    public override float Score { get; set; }

    public override void Attack()
    {
        Debug.Log($"テスト！ Attack");
    }
    
    public override void AddDamage()
    {
        Debug.Log($"テスト！ AddDamage");
    }
    
    public override void Dead()
    {
        Debug.Log($"テスト！ Dead");
    }
}
