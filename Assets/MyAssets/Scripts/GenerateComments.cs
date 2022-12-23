using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



/// <summary>
/// コメントの性質を表す基底クラス
/// <summary>
public class CommentsNature : MonoBehaviour{
    
    public float commentSpeed = 10.0f;

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
    public GameObject commentTextPrefab;
    public GameObject playerObjectPrefab;


    public IEnumerator GetComments(string comment){
    
        Transform playerTransform = playerObjectPrefab.transform;
        Vector3 playerPos = playerTransform.position;

        commentTextPrefab.GetComponent<TextMesh>().text = comment; //追加
        GameObject newTextObj = Instantiate(commentTextPrefab, new Vector3(playerPos.x, playerPos.y, playerPos.z), Quaternion.Euler(90, playerTransform.eulerAngles.y, 90)); //インスタンス化

        yield return new WaitForSeconds(0.1f);
        commentList.Remove(comment);
    }
 

}
