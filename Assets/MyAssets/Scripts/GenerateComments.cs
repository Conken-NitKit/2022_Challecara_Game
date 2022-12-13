using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


/// <summary>
/// コメントの性質を表す基底クラス
/// <summary>
class CommentsNature : MonoBehaviour{
    private float commentSpeed;
    private int attackPower;
    private int commentLength;
}



/// <summry>
/// コメントをテキスト化するクラス
/// <summry>
public class GenerateComments : MonoBehaviour
{

    List<string> commentList = new List<string>();
    public GameObject commentTextPrefab;

    public IEnumerator GetComments(string comment){
        Debug.Log(comment);
        commentTextPrefab.GetComponent<TextMesh>().text = comment; //追加
        yield return new WaitForSeconds(0.1f);
        commentList.Remove(comment);
    }
 

}
