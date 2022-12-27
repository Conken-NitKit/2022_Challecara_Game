using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// プレイヤーのコントローラークラス
/// これアタッチするだけで動いたりします
/// 必要ならTerrain、Animatorのアタッチをしてください。
/// </summary>
public class PlayerController : MonoBehaviour
{
    private static readonly int IS_MOVE_HASH = Animator.StringToHash("Walk");
    
    [SerializeField]
    private Animator _animator;
    
    [SerializeField]
    private Terrain _terrain;

    [SerializeField]
    private float _speed = 5f;

    [SerializeField]
    private float _rollSpeed = 180f;
    
    private void Update()
    {
        ControlMove();
        ControlDirection();
    }

    /// <summary>
    /// 実際にプレイヤーを動かすメソッド
    /// </summary>
    private void ControlMove()
    {
        Vector3 moveVector = GetMoveVertical();
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

    /// <summary>
    /// プレイヤーの方向を動かすクラス
    /// </summary>
    private void ControlDirection()
    {
        transform.Rotate(GetHorizontal() * Time.deltaTime * _rollSpeed);
    }

    /// <summary>
    /// WS、十字の前後のKeyを取得
    /// </summary>
    /// <returns>前後の動きのベクターを返す</returns>
    private Vector3 GetMoveVertical()
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

    /// <summary>
    /// AD、十字の左右のKeyを取得
    /// </summary>
    /// <returns>左右の方向の動きのベクターを返す</returns>
    private Vector3 GetHorizontal()
    {
        Vector3 moveVector = Vector3.zero;
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            moveVector += new Vector3(0, 1, 0);
        }

        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            moveVector += new Vector3(0, -1, 0);
        }

        return moveVector.normalized;
    }
}
