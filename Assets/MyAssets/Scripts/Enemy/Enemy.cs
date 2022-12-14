using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    public abstract float Hp { get; set; }
    public abstract float AttackPoint { get; set; }
    public abstract float Velocity { get; set; }
    public abstract float Score { get; set; }

    public abstract void Attack();
    public abstract void AddDamage();
    public abstract void Dead();
}
