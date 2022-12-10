using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///①テキスト３dオブジェクト化
///②球の動き

///③コメントを取得して球を動かせるように

/// <summary>
/// コメントを取得して扱うクラス
/// </summary>
public class Comments : MonoBehaviour
{

    List<string> commentList = new List<string>();
    
    private void Start()
    {
        FindObjectOfType<YoutubeComment>().BeginGetComments();
    }

    /// <summary>
    /// コメントを取得した時に実行する
    /// UseCommentTestの部分を実際の攻撃の実装に置き換えると良い
    /// </summary>
    public void OnComment(List<Comment> comments)
    {
        foreach(var c in comments)
        {
            commentList.Add(c.Message);
        }

        foreach (var comment in commentList)
        {
            //StartCoroutine(UseCommentTest(comment));
            //StartCoroutine(GetCommentLength(comment));
        }
    }

    /// <summary>
    /// コメントを扱うテスト
    /// Debug.Logの部分を実際の処理に変更するといいと思います
    /// </summary>
    /*private IEnumerator UseCommentTest(string comment)
    {
        //Debug.Log(comment);
        //yield return new WaitForSeconds(0.1f);
        //commentList.Remove(comment);
    }*/
}
