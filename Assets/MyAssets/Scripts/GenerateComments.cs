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
/// コメントをテキスト化して生成するクラス
/// <summry>
public class GenerateComments : MonoBehaviour
{

    List<string> commentList = new List<string>();
    public GameObject commentTextPrefab;
    //public GameObject textPrefab;


    void FixedUndate(){
        /*if(Input.GetKey(KeyCode.Space)){
            //GameObject.Destroy(commentTextPrefab);
            Debug.Log("!!!");
        }*/
    }

    public IEnumerator GetComments(string comment){
        Debug.Log(comment);
        commentTextPrefab.GetComponent<TextMesh>().text = comment; //追加
        GameObject newTextObj = Instantiate(commentTextPrefab, new Vector3( 1.47f, 1.0f, 0.97f), Quaternion.Euler(90, 0, 0)); //インスタンス化

        yield return new WaitForSeconds(0.1f);
        //GameObject.Destroy(commentTextPrefab);
        commentList.Remove(comment);
    }
 

}
