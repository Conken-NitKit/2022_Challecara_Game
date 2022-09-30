using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Comments : MonoBehaviour
{
    
    List<string> commentList = new List<string>();
    
    private void Start()
    {
        FindObjectOfType<YoutubeComment>().BeginGetComments();
    }

    private void OnComment(List<Comment> comments)
    {
        foreach(var c in comments)
        {
            commentList.Add(c.Message);
        }

        foreach (var comment in commentList)
        {
            StartCoroutine(UseCommentTest(comment));
        }
    }

    private IEnumerator UseCommentTest(string comment)
    {
        Debug.Log(comment);
        yield return new WaitForSeconds(0.1f);
        commentList.Remove(comment);
    }
}
