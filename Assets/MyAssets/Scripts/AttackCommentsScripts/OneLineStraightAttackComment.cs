using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// コメントを直進させる派生クラス
/// </summary>
public class OneLineStraightAttackComment : CommentsNature
{
    [SerializeField] GameObject oneLineStraightAttackComment_TextPrefab;
    private GameObject playerPrefab;
    [SerializeField] Rigidbody oneLineStraightAttackComment_Rigidbody;


    public void Start(){
        oneLineStraightAttackComment_Rigidbody.AddForce(transform.right * commentSpeed);
        //Debug.Log("1列に直行");
    }
}
