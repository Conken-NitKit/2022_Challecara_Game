using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// コメントを３列に分割して3方向に直進させる派生クラス (45 90 135)
/// </summary>
public class ThreeLineStraighAttackComment : CommentsNature
{
    [SerializeField] private TextMesh[] threeLineStraighAttackComment_Text;
    [SerializeField] private Rigidbody[] threeLineStraighAttackComment_Rigidbody;
    public string Text { get; set; }

    public void Start()
    {
        ConvertTextThreeLine();
        Vector3 vectorQuater = new Vector3(1, 1, 0);
        threeLineStraighAttackComment_Rigidbody[0].AddForce(transform.right - vectorQuater* commentSpeed);
        threeLineStraighAttackComment_Rigidbody[1].AddForce(transform.right * commentSpeed);
        threeLineStraighAttackComment_Rigidbody[2].AddForce(transform.right + vectorQuater * commentSpeed);
        Debug.Log("3列に分岐");
    }

    private void ConvertTextThreeLine()
    {
        string[] textParts = new string[3]; 
        Debug.Log($"{Text}");
        textParts[0] = Text.Substring(0,Text.Length/3 );
        textParts[1] = Text.Substring(Text.Length/3, Text.Length/3);
        textParts[2] = Text.Substring(2*Text.Length/3 );
        for (int i = 0; i < 3; i++)
        {
            threeLineStraighAttackComment_Text[i].text = textParts[i];
        }
    }
}
