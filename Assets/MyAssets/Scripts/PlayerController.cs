using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// プレイヤーを十字キーとタップで移動させ、移動している方向に回転するようにした
/// </summary>

public class PlayerController : MonoBehaviour
{
    float horizontalKeyInput = 0;
    float verticalKeyInput = 0;

    Vector2 StartTouch = new Vector2();
    Vector2 TouchInput = new Vector2();

    bool isTouch = false;

    [SerializeField] Animator anim;
    [SerializeField] Rigidbody rigid;

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

        else
        {
            horizontalKeyInput = Input.GetAxis( "Horizontal" );
            verticalKeyInput = Input.GetAxis( "Vertical" );
        }

        bool isKeyInput = ( horizontalKeyInput != 0 || verticalKeyInput != 0 || TouchInput != Vector2.zero );
        if( isKeyInput == true )
        {
            Vector3 dir = rigid.velocity.normalized;
            dir.y = 0;
            this.transform.forward = dir;
        }
    }

    void FixedUpdate()
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
    }
}
