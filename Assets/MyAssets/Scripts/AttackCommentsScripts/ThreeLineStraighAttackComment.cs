using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// コメントを３列に分割して3方向に直進させる派生クラス
/// </summary>
public class ThreeLineStraighAttackComment : CommentsNature
{
    [SerializeField] GameObject threeLineStraighAttackComment_TextPrefab;
    private GameObject playerPrefab;
    [SerializeField] Rigidbody threeLineStraighAttackComment_Rigidbody;


    void Start(){
        //commentRigidbody.AddForce(transform.right * commentSpeed);
    }
}
