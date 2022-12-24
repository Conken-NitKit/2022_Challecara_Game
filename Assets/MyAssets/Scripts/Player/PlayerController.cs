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

    [SerializeField] Animator anim;
    [SerializeField] Rigidbody rigid;

    [SerializeField] private Terrain terrain;

    void Update()
    {
        if (Input.anyKey)
        {
            anim.SetBool ( "Walk", true );
        }
        else
        {
            anim.SetBool ( "Walk", false );
        }

        if( Application.platform == RuntimePlatform.Android || Application.platform == RuntimePlatform.IPhonePlayer )
        {
            Touch[] touches;

            if(Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);
                isTouch = true;
                touches = Input.touches;
                
                if(isTouch = true)
                {
                    if (touch.phase == TouchPhase.Began)
                    {
                        StartTouch = touch.position;
                        Vector3 touchPosition = touch.position;
                        touchPosition.z = 1f;
                    }
                        
                    else if (touch.phase == TouchPhase.Moved || touch.phase == TouchPhase.Stationary)
                    {      
                        Vector2 position = touch.position;
                        TouchInput = position - StartTouch;
                    }
                    else if (touch.phase == TouchPhase.Ended)
                    {
                        TouchInput = Vector2.zero;
                    }
                }
            }
            else
            {
                isTouch = false;
            }
        }
        
        moveVector = Vector3.zero;
 
        moveVector += transform.forward * Input.GetAxis( "Vertical" );
        moveVector += transform.right * Input.GetAxis( "Horizontal" );

        bool isKeyInput = ( Input.GetAxis( "Horizontal" ) != 0 || Input.GetAxis( "Vertical" ) != 0 || TouchInput != Vector2.zero );
        if( isKeyInput )
        {
            Vector3 moveDelta;
            moveDelta = moveVector * Time.deltaTime * playerMoveSpeed;

            Vector3 taragetPosition = transform.position + moveDelta;
            taragetPosition.y = terrain.SampleHeight(taragetPosition);

            moveDelta = taragetPosition - transform.position;
            moveDelta = moveDelta.normalized * Time.deltaTime * playerMoveSpeed;

            transform.position += moveDelta;
            latestPos = transform.position;
            
            Quaternion lookRotation = Quaternion.LookRotation(
                new Vector3(moveVector.x, 0f, moveVector.z));
            transform.rotation = Quaternion.RotateTowards(
                transform.rotation,
                lookRotation, Time.deltaTime * playerRollSpeed);
        }
    }

    /*void FixedUpdate()
    {
        Vector3 input = new Vector3();
        Vector3 move = new Vector3();
        if( Application.platform == RuntimePlatform.Android || Application.platform == RuntimePlatform.IPhonePlayer )
        {
            input = new Vector3( TouchInput.x, 0, TouchInput.y );
            move = input.normalized * 2f;
        }
        else
        {
            input = new Vector3( horizontalKeyInput, 0, verticalKeyInput );
            move = input.normalized * 2f;
        }
        Vector3 cameraMove = Camera.main.gameObject.transform.rotation * move;
        cameraMove.y = 0;
        Vector3 currentRigidVelocity = rigid.velocity;
        currentRigidVelocity.y = 0;
 
        rigid.AddForce( cameraMove - rigid.velocity, ForceMode.VelocityChange );
    }*/
}
