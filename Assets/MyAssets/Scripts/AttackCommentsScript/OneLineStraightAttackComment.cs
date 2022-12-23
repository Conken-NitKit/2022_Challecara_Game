using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// コメントを直進させる派生クラス
/// </summary>
public class OneLineStraightAttackComment : CommentsNature
{
    public GameObject oneLineStraightAttackCommentTextPrefab;
   

    void FixedUpdate(){
        //Transform playerTransform = playerObject.transform;
        //Vector3 playerPos = playerTransform.position;

        //Instantiate(commentTextPrefab, new Vector3(playerPos.x, playerPos.y, playerPos.z), commentTextPrefab.transform.rotation);
        oneLineStraightAttackCommentTextPrefab.transform.position += new Vector3(0, 0, 1) * commentSpeed;
    }
}
