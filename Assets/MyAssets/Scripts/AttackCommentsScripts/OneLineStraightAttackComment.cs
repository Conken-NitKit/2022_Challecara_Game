using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// コメントを直進させる派生クラス
/// </summary>
public class OneLineStraightAttackComment : CommentsNature
{
    [SerializeField] private TextMesh oneLineStraightAttackComment_Text;
    [SerializeField] private Rigidbody oneLineStraightAttackComment_Rigidbody;
    //public string Text { get; set; }


    public void Start()
    {
        oneLineStraightAttackComment_Rigidbody.AddForce(transform.right * commentSpeed);
        //Debug.Log("1列に直行");
    }
}
