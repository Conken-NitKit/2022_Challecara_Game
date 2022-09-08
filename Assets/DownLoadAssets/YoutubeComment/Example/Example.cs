using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Example : MonoBehaviour
{
    [SerializeField]
    GameObject sphere;

    [SerializeField]
    UnityEngine.UI.Text text;

    List<string> commentList = new List<string>();


    private void Start()
    {
        FindObjectOfType<YoutubeComment>().BeginGetComments();
    }

    public void OnComment(List<Comment> comments)
    {
        foreach(var c in comments)
        {
            commentList.Add(c.Message);
        }

        while(commentList.Count > 20)
        {
            commentList.RemoveAt(0);
        }

        text.text = "";
        foreach (var c in commentList)
        {
            text.text += $"{c}\n\n";
        }
    }

    public void OnSuperChat(Comment comment)
    {
        Debug.Log($"<color=red>{comment.SuperChatComment}->{comment.AmountDisplay}({comment.AmountMicros})</color>");

        var go = Instantiate(sphere);
        go.transform.position = Vector3.up * 10f;
    }
}
