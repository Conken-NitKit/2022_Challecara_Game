using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController1 : MonoBehaviour
{
    private static readonly int IS_MOVE_HASH = Animator.StringToHash("Walk");
    
    [SerializeField]
    private Animator _animator;
    
    [SerializeField]
    private Terrain _terrain;

    [SerializeField]
    private float _speed = 3f;
    
    private void Update()
    {
        ControlMove();
        ControlDirection();
    }

    private void ControlMove()
    {
        Vector3 moveVector = GetMoveVector();
        bool isMove = moveVector != Vector3.zero;
        
        if (_animator != null)
        {
            _animator.SetBool(IS_MOVE_HASH, isMove);
        }
        
        if (isMove)
        {
            transform.position += moveVector * Time.deltaTime * _speed;
            

            // テレインに沿って高さを合わせる
            if (_terrain != null)
            {
                Vector3 position = transform.position;
                position.y = _terrain.SampleHeight(position);
                transform.position = position;
            }
        }
        
    }

    private void ControlDirection()
    {
        
    }

    private Vector3 GetMoveVector()
    {
        Vector3 moveVector = Vector3.zero;
        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
        {
            moveVector += transform.forward;
        }

        if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
        {
            moveVector += -1 * transform.forward;
        }
        return moveVector.normalized;
    }
}
