using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    protected abstract float Hp { get; set; }
    protected abstract float AttackPoint { get; set; }
    protected abstract float Velocity { get; set; }
    protected abstract float Score { get; set; }

    protected void Attack()
    {
        Debug.Log($"基底クラスの記述です @{this.gameObject.name}.Attack");
    }
    
    protected void AddDamage()
    {
        Debug.Log($"基底クラスの記述です @{this.gameObject.name}.AddDamage");
    }
    
    protected void Dead()
    {
        Debug.Log($"基底クラスの記述です @{this.gameObject.name}.Dead");
    }
}
