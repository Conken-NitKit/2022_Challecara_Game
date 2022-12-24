using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// コメントを３列に分割して3方向に直進させる派生クラス (45 90 135)
/// </summary>
public class ThreeLineStraighAttackComment : CommentsNature
{
    [SerializeField] GameObject threeLineStraighAttackComment_TextPrefab;
    private GameObject playerPrefab;
    [SerializeField] Rigidbody threeLineStraighAttackComment_Rigidbody;


    public void Start(){
        //threeLineStraighAttackComment_Rigidbody.AddForce(transform.right * commentSpeed);
        Debug.Log("3列に分岐");
    }
}
