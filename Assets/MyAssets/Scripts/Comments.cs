using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

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
        if(comments.Count >= 5){
            comments.RemoveRange(0, comments.Count -5);
        }

        foreach(var c in comments)
        {
            commentList.Add(c.Message);
        }

        foreach (var comment in commentList)
        {
            StartCoroutine(generateComments.GetComments(comment));
        }
    }

    
}
