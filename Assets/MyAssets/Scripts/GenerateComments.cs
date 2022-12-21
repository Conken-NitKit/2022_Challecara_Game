using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



/// <summary>
/// コメントの性質を表す基底クラス
/// <summary>
public class CommentsNature : MonoBehaviour{
    
    //public GameObject commentTextPrefab;
    public float commentSpeed = 10.0f;
    //public float attackPower;
    //public int commentLength;
    //public Vector3 commentStartPos;

    public virtual void Hoge(){
        //Debug.Log(commentTextPrefab.transform.position);
    }
    

}


/// <summry>
/// コメントをテキスト化して生成するクラス
/// <summry>
public class GenerateComments : MonoBehaviour
{
    List<string> commentList = new List<string>();
    public GameObject commentTextPrefab;


    public IEnumerator GetComments(string comment){
        Debug.Log(comment);
        commentTextPrefab.GetComponent<TextMesh>().text = comment; //追加
        GameObject newTextObj = Instantiate(commentTextPrefab, new Vector3( 1.47f, 1.0f, 0.97f), Quaternion.Euler(90, 0, 90)); //インスタンス化

        yield return new WaitForSeconds(0.1f);
        commentList.Remove(comment);
    }
 

}
