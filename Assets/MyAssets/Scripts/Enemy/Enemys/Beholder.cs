using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;
using System;
using UniRx;

public class Beholder : Enemy
{
    private static EnemyParams param = null;
    private static EnemyParams Params => param ?? (param = Resources.Load<EnemyParams>("EnemyDatas/Beholder"));

    [SerializeField]
    private GameObject attackRange;
    
    private ScoreManager scoreManager;
    
    private float seconds = 0.3f;

    private void Start()
    {
        scoreManager = GameObject.FindWithTag("Manager").GetComponent<ScoreManager>();
    }
    
    public override void Init()
    {
        Hp = Params.maxHp;
        gameObject.SetActive(true);
        StartCoroutine(hoge());
    }

    public override void Attack()
    {
        attackRange.SetActive(true);
    }
    
    public override void AddedDamage(float damage)
    {
        Hp -= damage;
        
        Debug.Log(Hp);
        
        if (Hp < 0)
        {
            Dead();
        }
    }
    
    public override async void Dead()
    {
        scoreManager.AddScore(1);
        await UniTask.Delay(TimeSpan.FromSeconds(seconds));
        gameObject.SetActive(false);
    }

    IEnumerator hoge()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            AddedDamage(1);
        }
    }
}
