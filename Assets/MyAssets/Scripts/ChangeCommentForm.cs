using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 取得したコメントをPlayerTagの付いてるオブジェクトの座標位置から出力するクラス
/// <summary>
public class ChangeCommentForm : MonoBehaviour
{
    void Start()
    {

    }


    void FixedUpdate()
    {
        Transform myTransform = this.transform;
        Vector3 playerPos = myTransform.position;

        Debug.Log(playerPos.x + "," + playerPos.y + "," + playerPos.z);
    }
}
