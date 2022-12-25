using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// プレイヤーの移動処理クラス
/// </summary>

public class PlayerController : MonoBehaviour
{
    float horizontalKeyInput = 0;
    float verticalKeyInput = 0;

    [SerializeField]
    private float playerMoveSpeed = 5;
    
    [SerializeField]
    private float playerRollSpeed = 120f;

    Vector2 StartTouch = new Vector2();
    Vector2 TouchInput = new Vector2();

    private Vector3 moveVector;
    
    private Vector3 latestPos = new Vector3();
    
    private string groundTag = "Ground";
    private bool isGround = false;

    bool isTouch = false;
    
    [SerializeField]
    private Transform _camera;
    
    private static readonly int IS_MOVE_HASH = Animator.StringToHash("Walk");

    [SerializeField] Animator anim;
    [SerializeField] Rigidbody rigid;

    [SerializeField] private Terrain terrain;
 

    void Update()
    {
        moveVector = Vector3.zero;

        bool isKeyInput = ( Input.GetAxis( "Horizontal" ) != 0 || Input.GetAxis( "Vertical" ) != 0 || TouchInput != Vector2.zero );
        
        if (isKeyInput)
        {
            anim.SetBool ( IS_MOVE_HASH, true );
        }
        else
        {
            anim.SetBool ( IS_MOVE_HASH, false );
        }

        if( isKeyInput )
        {
            moveVector += transform.forward * Input.GetAxis( "Vertical" );
            moveVector += transform.right * Input.GetAxis( "Horizontal" );
            Vector3 moveDelta;
            moveDelta = moveVector * Time.deltaTime * playerMoveSpeed;

            Vector3 taragetPosition = transform.position + moveDelta;
            taragetPosition.y = terrain.SampleHeight(taragetPosition);

            moveDelta = taragetPosition - transform.position;
            moveDelta = moveDelta.normalized * Time.deltaTime * playerMoveSpeed;

            transform.position += moveDelta;
            latestPos = transform.position;
            
            Quaternion lookRotation = Quaternion.LookRotation(
                moveVector);
            transform.rotation = Quaternion.RotateTowards(
                transform.rotation,
                lookRotation, Time.deltaTime * playerRollSpeed);
        }
    }
}
