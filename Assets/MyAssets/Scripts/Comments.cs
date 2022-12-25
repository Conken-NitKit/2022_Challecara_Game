using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

/// <summary>
/// コメントを取得して扱うクラス
/// </summary>
public class Comments : MonoBehaviour
{

    List<string> commentList = new List<string>();
    [SerializeField] GenerateComments generateComments;

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
        Debug.Log("hage");
        if(comments.Count > 1){
            //CommentList内のコメントを最新のもの以外は削除する
            comments.RemoveRange(0, comments.Count -1);
        }

        foreach(var c in comments)
        {
            commentList.Add(c.Message);
        }

        StartCoroutine(generateComments.GetComments(commentList.Last()));
    }
}
