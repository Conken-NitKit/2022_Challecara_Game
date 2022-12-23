using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

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

    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
        currentState = new Pursue(this.gameObject, agent, player, animator, true);
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
