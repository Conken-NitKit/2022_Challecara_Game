using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    [SerializeField]
    private NavMeshAgent agent;
    private Transform player;
    
    private EnemyState currentState;

    [SerializeField]
    private Animator animator;

    void Start()
    {
        agent = this.gameObject.GetComponent<NavMeshAgent>();
        animator = this.gameObject.GetComponent<Animator>();
        player = GameObject.FindWithTag("Player").transform;
        currentState = new Pursue(this.gameObject, agent, player, animator);
        Debug.Log(currentState);
    }

    void Update()
    {
        currentState = currentState.Process();
    }
}
