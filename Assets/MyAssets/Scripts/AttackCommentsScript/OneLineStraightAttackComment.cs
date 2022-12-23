using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// コメントを直進させる派生クラス
/// </summary>
public class OneLineStraightAttackComment : CommentsNature
{
    [SerializeField] GameObject oneLineStraightAttackCommentTextPrefab;
    private GameObject playerPrefab;
    [SerializeField] Rigidbody commentRigidbody;

    void Start(){
        commentRigidbody.AddForce(transform.right * commentSpeed);
    }
}
