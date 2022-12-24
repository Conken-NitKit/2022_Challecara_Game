using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 5文字のコメントを1文字ずつに分割して半円状に直進させる派生クラス
/// </summary>
public class HalfCircleAttackComment : CommentsNature
{
    [SerializeField] GameObject halfCircleAttackComment_TextPrefab;
    private GameObject playerPrefab;
    [SerializeField] Rigidbody halfCircleAttackComment_Rigidbody;


    void Start(){
        //commentRigidbody.AddForce(transform.right * commentSpeed);
    }
}
