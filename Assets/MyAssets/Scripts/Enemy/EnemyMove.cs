using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UniRx;

public class EnemyMove : MonoBehaviour
{
    [SerializeField]
    private NavMeshAgent agent;
    private Transform player;
    
    private EnemyState currentState;

    [SerializeField]
    private Animator animator;

    [SerializeField]
    private Enemy enemy;
    
    private static EnemyParams param = null;

    [SerializeField]
    private string enemyName;

    void Start()
    {
        param = Resources.Load<EnemyParams>($"EnemyDatas/{enemyName}");
        player = GameObject.FindWithTag("Player").transform;
        currentState = new Pursue(this.gameObject, agent, player, animator, true, param.speed);

    }

    void Update()
    {
        currentState = currentState.Process();
        if (currentState.name.ToString() == "ATTACK")
        {
            enemy.Attack();
        }
    }
}
