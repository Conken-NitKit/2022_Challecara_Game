using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Cysharp.Threading.Tasks;
using System;
using UnityEditor;


/// <summary>
/// Stateパターン使ってみました
/// Stateパターン的にこの処理どうなの？ってのがいくつかありますがまあ大丈夫でしょう
/// 結構急ピッチでそのまま使っちゃってるところも多いですけど改良します
/// </summary>
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

    protected int pursueSpeed;

    protected bool canAttack;
    
    protected bool isDie;

    readonly float visDist = 10.0f;
    readonly float visAngle = 30.0f;

    readonly float shootDist = 4.5f;

    readonly float rotationSpeed = 2.0f;

    public static readonly int IS_MOVE_HASH = Animator.StringToHash("IsMove");
    public static readonly int IS_ATTACK_HASH = Animator.StringToHash("IsAttack");
    public static readonly int IS_IDLE_HASH = Animator.StringToHash("IsIdle");
    public static readonly int IS_DIE_HASH = Animator.StringToHash("IsDie");

    public EnemyState(GameObject _enemy, NavMeshAgent _agent, Transform _player, Animator _animator, bool _canAttack, int _pursueSpeed)
    {
        enemy = _enemy;
        agent = _agent;
        stage = EVENT.ENTER;
        player = _player;
        animator = _animator;
        canAttack = _canAttack;
        pursueSpeed = _pursueSpeed;
        isDie = false;
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

    /// <summary>
    /// プレイヤーが攻撃できるかどうかをブールで返す
    /// </summary>
    public bool GetAttackPlayer()
    {
        Vector3 direction = player.position - enemy.transform.position;
        if (direction.magnitude < shootDist)
        {
            return true;
        }
        return false;
    }

    /// <summary>
    /// プレイヤーを見つめ続けるメソッド
    /// </summary>
    public void LookAtPlayer()
    {
        Vector3 direction = player.position - enemy.transform.position;
        float angle = Vector3.Angle(direction, enemy.transform.position);
        direction.y = 0;
        
        enemy.transform.rotation = Quaternion.Slerp(enemy.transform.rotation,
            Quaternion.LookRotation(direction),
            Time.deltaTime * rotationSpeed);
    }

    /// <summary>
    /// 攻撃待ちの処理
    /// </summary>
    /// <param name="seconds"></param>
    public async UniTask WaitAttack(float seconds)
    {
        canAttack = false;
        await UniTask.Delay(TimeSpan.FromSeconds(seconds));
        canAttack = true;
    }

    public void SetDieBool()
    {
        isDie = true;
    }
}

/// <summary>
/// 棒立ちのステート
/// 攻撃待ちの状態
/// </summary>
public class Idle : EnemyState
{
    public Idle(GameObject _enemy, NavMeshAgent _agent, Transform _player, Animator _animator, bool _canAttack, int _pursueSpeed) : base(_enemy, _agent, _player, _animator , _canAttack, _pursueSpeed)
    {
        name = STATE.IDLE;
        agent.isStopped = true;
        animator.SetBool(IS_IDLE_HASH, true);
        
        WaitAttack(3).Forget();
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Update()
    {
        LookAtPlayer();

        if (isDie)
        {
            nextState = new Die(enemy, agent, player, animator, canAttack, pursueSpeed);
            stage = EVENT.EXIT;
        }
        
        if (GetAttackPlayer() && canAttack)
        {
            nextState = new Attack(enemy, agent, player, animator, canAttack, pursueSpeed);
            stage = EVENT.EXIT;
        }
        
        if (!GetAttackPlayer())
        {
            nextState = new Pursue(enemy, agent, player, animator, canAttack, pursueSpeed);
            stage = EVENT.EXIT;
        }
    }

    public override void Exit()
    {
        animator.SetBool(IS_IDLE_HASH, false);
        base.Exit();
    }
}

/// <summary>
/// プレイヤーを追いかけるステート
/// エネミーの基本状態だったりします
/// </summary>
public class Pursue : EnemyState
{
    
    public Pursue(GameObject _enemy, NavMeshAgent _agent, Transform _player, Animator _animator, bool _canAttack, int _pursueSpeed) : base(_enemy, _agent, _player, _animator , _canAttack, _pursueSpeed)
    {
        name = STATE.PURSUE;
        agent.isStopped = false;
        agent.speed = pursueSpeed;
        agent.SetDestination(player.transform.position);
        animator.SetBool(IS_MOVE_HASH, true);
    }
    
    public override void Enter()
    {
        base.Enter();
    }

    public override void Update()
    {
        if (isDie)
        {
            nextState = new Die(enemy, agent, player, animator, canAttack, pursueSpeed);
            stage = EVENT.EXIT;
        }
        
        if (GetAttackPlayer())
        {
            nextState = new Attack(enemy, agent, player, animator, canAttack, pursueSpeed);
            stage = EVENT.EXIT;
        }
        agent.SetDestination(player.transform.position);
    }

    public override void Exit()
    {
        animator.SetBool(IS_MOVE_HASH, false);
        base.Exit();
    }
}

/// <summary>
/// プレイヤーを攻撃するステート
/// </summary>
public class Attack : EnemyState
{
    public Attack(GameObject _enemy, NavMeshAgent _agent, Transform _player, Animator _animator, bool _canAttack, int _pursueSpeed) : base(_enemy, _agent, _player, _animator , _canAttack, _pursueSpeed)
    {
        name = STATE.ATTACK;
        agent.isStopped = true;
        animator.SetBool(IS_ATTACK_HASH, true);

        canAttack = true;
    }

    public override void Enter()
    {
        agent.isStopped = true;
        base.Enter();
    }

    public override void Update()
    {
        if (isDie)
        {
            nextState = new Die(enemy, agent, player, animator, canAttack, pursueSpeed);
            stage = EVENT.EXIT;
        }
        
        LookAtPlayer();
        if (GetAttackPlayer() && canAttack)
        {
            nextState = new Idle(enemy, agent, player, animator, canAttack, pursueSpeed);
            stage = EVENT.EXIT;
        }

        if (!GetAttackPlayer())
        {
            nextState = new Pursue(enemy, agent, player, animator, canAttack, pursueSpeed);
            stage = EVENT.EXIT;
        }
    }

    public override void Exit()
    {
        animator.SetBool(IS_ATTACK_HASH, false);
        base.Exit();
    }
}

/// <summary>
/// 死んだ状態のステート
/// 結局使えませんでした
/// </summary>
public class Die : EnemyState
{
    public Die(GameObject _enemy, NavMeshAgent _agent, Transform _player, Animator _animator, bool _canAttack, int _pursueSpeed) : base(_enemy, _agent, _player, _animator , _canAttack, _pursueSpeed)
    {
        name = STATE.DIE;
        animator.SetBool(IS_DIE_HASH, true);
        stage = EVENT.EXIT;
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
        animator.SetBool(IS_DIE_HASH, false);
        isDie = false;
        nextState = new Pursue(enemy, agent, player, animator, canAttack, pursueSpeed);
        base.Exit();
    }
}