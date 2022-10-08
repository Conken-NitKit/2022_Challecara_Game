using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class EnemyMove: MonoBehaviour
{
    [SerializeField]
    private Transform m_Target;

    [SerializeField]
    private NavMeshAgent m_Agent;
    void Update()
    {
        m_Agent.SetDestination(m_Target.position);
    }
}