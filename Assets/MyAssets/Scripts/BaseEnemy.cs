using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseEnemy : MonoBehaviour
{
    protected abstract float Hp { get; set; }
    protected abstract float AttackPoint { get; set; }
    protected abstract float Velocity { get; set; }
    protected abstract float Score { get; set; }
}
