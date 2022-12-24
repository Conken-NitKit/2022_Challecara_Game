using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



/// <summary>
/// コメントの性質を表す基底クラス
/// <summary>
public class CommentsNature : MonoBehaviour{
    
    public float commentSpeed = 100.0f;

    //public float attackPower;
    //public int commentLength;
    //public Vector3 commentStartPos;

}


/// <summry>
/// コメントをテキスト化して生成するクラス
/// <summry>
public class GenerateComments : MonoBehaviour
{
    List<string> commentList = new List<string>();

    public GameObject oneLineStraightAttackComment_TextPrefab; //1直線
    public GameObject threeLineStraighAttackComment_TextPrefab; //3方向に直進
    public GameObject halfCircleAttackComment_Rigidbody; //5文字のコメントを半円状に
    
    public GameObject playerObjectPrefab;


    public IEnumerator GetComments(string comment){
        //取得したコメントの半角と全角の空白を消去
        string commentReplaceAfter = comment.Replace(" ","").Replace("　","");
        Debug.Log(commentReplaceAfter);
    
        //取得したコメントを発射する座標であるプレイヤーの座標の取得
        Transform playerTransform = playerObjectPrefab.transform;
        Vector3 playerPos = playerTransform.position;
        
        //コメントの３DオブジェクトのプレハブにあるTextMeshに入力されたコメントを代入したもののインスタンス化
        oneLineStraightAttackComment_TextPrefab.GetComponent<TextMesh>().text = commentReplaceAfter; 
        GameObject newTextObj = Instantiate(oneLineStraightAttackComment_TextPrefab, new Vector3(playerPos.x, playerPos.y, playerPos.z), Quaternion.Euler(90, playerTransform.eulerAngles.y, 90)); //インスタンス化
    

        yield return new WaitForSeconds(0.1f);
        commentList.Remove(comment);
    }
 

}
