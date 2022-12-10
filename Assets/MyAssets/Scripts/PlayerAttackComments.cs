using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// コメントの長さによってオブジェクトをインスタンス化
/// <summary>
public class PlayerAttackComments : MonoBehaviour
{
    List<string> getCommentList = new List<string>();

    private void Start(){
       FindObjectOfType<Comments>().OnComment(List<Comments> comments);
    }

    /// <summary>
    /// コメントの長さを取得
    /// <summary>
    private IEnumerator GetCommentLength(string comment){
        Debug.Log(comment);
        yield return new WaitForSeconds(0.1f);
        getCommentList.Remove(comment);
    }

}