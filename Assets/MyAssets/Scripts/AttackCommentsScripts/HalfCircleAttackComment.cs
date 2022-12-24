using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 5文字のコメントを1文字ずつに分割して半円状に直進させる派生クラス (30 60 90 120 150)
/// </summary>
public class HalfCircleAttackComment : CommentsNature
{
    [SerializeField] GameObject halfCircleAttackComment_TextPrefab;
    private GameObject playerPrefab;
    [SerializeField] Rigidbody halfCircleAttackComment_Rigidbody;


    public void Start(){
        //halfCircleAttackComment_Rigidbody.AddForce(transform.right * commentSpeed);
        Debug.Log("5文字に分岐");
    }
}
