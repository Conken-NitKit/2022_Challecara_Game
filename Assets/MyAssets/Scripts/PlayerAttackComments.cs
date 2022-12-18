using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// コメントの長さによってオブジェクトをインスタンス化
/// <summary>
public class PlayerAttackComments : MonoBehaviour
{
    private Vector3 commentStartPos;
    public float commentSpeed;
    [SerializeField] GameObject playerObject;

    void FixedUpdate(){
        Transform playerTransform = playerObject.transform;
        Vector3 playerPos = playerTransform.position;
        Vector3 playerRot = playerTransform.eulerAngles;

        commentStartPos = new Vector3(playerPos.x, playerPos.y, playerPos.z);
        //transform.position += new Vector3(0.5f*Time.deltaTime, 0f, 0f);
    }

}