using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    protected static EnemyParams Params;
    protected float Hp;

    public abstract void Attack();
    public abstract void AddedDamage(float damege);
    public abstract void Dead();
    public abstract void Init();
}
