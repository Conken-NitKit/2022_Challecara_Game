using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System.Threading.Tasks;
using UnityEditor;

public class EnemyState
{
    public enum STATE
    {
        IDLE,
        PURSUE,
        ATTACK,
        DIE
    };

    public enum EVENT
    {
        ENTER,
        UPDATE,
        EXIT
    };

    public STATE name;
    protected EVENT stage;
    protected GameObject enemy;
    protected Transform player;
    protected EnemyState nextState;
    protected NavMeshAgent agent;
    protected Animator animator;

    readonly float visDist = 10.0f;
    readonly float visAngle = 30.0f;

    readonly float shootDist = 7.0f;

    public static readonly int IS_MOVE_HASH = Animator.StringToHash("IsMove");

    public EnemyState(GameObject _enemy, NavMeshAgent _agent, Transform _player, Animator _animator)
    {
        enemy = _enemy;
        agent = _agent;
        stage = EVENT.ENTER;
        player = _player;
        animator = _animator;
    }

    public virtual void Enter()
    {
        stage = EVENT.UPDATE;
    }
    
    public virtual void Update()
    {
        stage = EVENT.UPDATE;
    } 
    
    public virtual void Exit()
    {
        stage = EVENT.EXIT;
    }

    public EnemyState Process()
    {
        if (stage == EVENT.ENTER) Enter();
        if (stage == EVENT.UPDATE) Update();
        if (stage == EVENT.EXIT)
        {
            Exit();
            return nextState; // 次のStateを返却
        }
        return this; // 現在のStateを返却
    }
    
    public bool CanSeePlayer()
    {
        Vector3 direction = player.position - enemy.transform.position;

        float angle = Vector3.Angle(direction, enemy.transform.position);

        if (direction.magnitude < visDist && angle < visAngle)
        {
            return true;
        }

        return false;
    }

    public bool GetAttackPlayer()
    {
        Vector3 direction = player.position - enemy.transform.position;
        if (direction.magnitude < shootDist)
        {
            return true;
        }
        return false;
    }
}

public class Idle : EnemyState
{
    public Idle(GameObject _enemy, NavMeshAgent _agent, Transform _player, Animator _animator) : base(_enemy, _agent, _player, _animator)
    {
        name = STATE.IDLE;
        agent.isStopped = true;
        Debug.Log("Idle");
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Update()
    {
        stage = EVENT.EXIT;
    }

    public override void Exit()
    {
        base.Exit();
    }
}

public class Pursue : EnemyState
{
    
    public Pursue(GameObject _enemy, NavMeshAgent _agent, Transform _player, Animator _animator) : base(_enemy, _agent, _player, _animator)
    {
        name = STATE.PURSUE;
        agent.isStopped = false;
        agent.speed = 5;
        agent.SetDestination(player.transform.position);
        animator.SetBool(IS_MOVE_HASH, true);
        Debug.Log("Pursue");
    }
    
    public override void Enter()
    {
        base.Enter();
    }

    public override void Update()
    {
        if (GetAttackPlayer())
        {
            nextState = new Attack(enemy, agent, player, animator);
            stage = EVENT.EXIT;
        }
        agent.SetDestination(player.transform.position);
    }

    public override void Exit()
    {
        base.Exit();
    }
}

public class Attack : EnemyState
{
    float rotationSpeed = 2.0f;
    public Attack(GameObject _enemy, NavMeshAgent _agent, Transform _player, Animator _animator) : base(_enemy, _agent, _player, _animator)
    {
        name = STATE.ATTACK;
        agent.isStopped = true;
        Debug.Log("Attack");
    }

    public override void Enter()
    {
        agent.isStopped = true;
        base.Enter();
    }

    public override void Update()
    {
        Vector3 direction = player.position - enemy.transform.position;
        float angle = Vector3.Angle(direction, enemy.transform.position);
        direction.y = 0;
        
        enemy.transform.rotation = Quaternion.Slerp(enemy.transform.rotation,
                                                    Quaternion.LookRotation(direction),
                                                    Time.deltaTime * rotationSpeed);

        if (!GetAttackPlayer())
        {
            nextState = new Pursue(enemy, agent, player, animator);
            stage = EVENT.EXIT;
        }
    }

    public override void Exit()
    {
        base.Exit();
    }
}
public class Die : EnemyState
{
    public Die(GameObject _enemy, NavMeshAgent _agent, Transform _player, Animator _animator) : base(_enemy, _agent, _player, _animator)
    {
        name = STATE.DIE;
        Debug.Log("Die");
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Update()
    {
        base.Update();
    }

    public override void Exit()
    {
        base.Exit();
    }
}