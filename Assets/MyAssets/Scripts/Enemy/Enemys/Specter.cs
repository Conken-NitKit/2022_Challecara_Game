using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Specter : Enemy
{
    private static EnemyParams param = null;
    private static EnemyParams Params => param ?? (param = Resources.Load<EnemyParams>("EnemyDatas/Specter"));

    [SerializeField]
    private GameObject attackRange;
    
    private ScoreManager scoreManager;

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
    
    public override void Dead()
    {
        scoreManager.AddScore(1);
        gameObject.SetActive(false);
    }
}
