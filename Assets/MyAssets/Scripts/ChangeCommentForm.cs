using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 取得したコメントをplayerObjectの座標位置から出力するクラス
/// <summary>
public class ChangeCommentForm : MonoBehaviour
{
    [SerializeField] GameObject playerObject;
    [SerializeField] Text commentText;

    void Start()
    {

    }

    void FixedUpdate()
    {   
        Transform playerTransform = playerObject.transform;
        Vector3 playerPos = playerTransform.position;
        Debug.Log(playerPos.x);
    }
}
