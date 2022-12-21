using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    private NavMeshAgent agent;
    private Transform player;

    private EnemyState currentState;

    void Start()
    {
        agent = this.gameObject.GetComponent<NavMeshAgent>();
        player = GameObject.FindWithTag("Player").transform;
        currentState = new Pursue(this.gameObject, agent, player);
        Debug.Log(currentState);
    }

    void Update()
    {
        currentState = currentState.Process();
    }
}
