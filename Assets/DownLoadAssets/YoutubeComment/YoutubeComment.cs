using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.Events;

[System.Serializable]
public class CommentListEvent : UnityEvent<List<Comment>>
{
}

[System.Serializable]
public class SuperChatEvent : UnityEvent<Comment>
{
}

[System.Serializable]
public class Comment
{
    /// <summary>コメントのID</summary>
    public string ID;
    /// <summary>コメントのタイムスタンプ</summary>
    public System.DateTime TimeStamp;
    /// <summary>発言者</summary>
    public string AuthorName;
    /// <summary>発言者のアイコンURL</summary>
    public string Icon;
    /// <summary>コメント</summary>
    public string Message;
    /// <summary>スパチャのみ 課金額</summary>
    public string AmountDisplay;
    /// <summary>スパチャのみ $1=1000000としたときの課金額</summary>
    public string AmountMicros;
    /// <summary>スパチャのみ コメント本体</summary>
    public string SuperChatComment;
}

public class YoutubeComment : MonoBehaviour
{
    [SerializeField] private string APIKEY;

    private string VideoID;

    [SerializeField]
    float GetCommentInterval = 3f;

    [SerializeField]
    bool playOnAwake = false;

    [SerializeField]
    CommentListEvent onComment;

    [SerializeField]
    SuperChatEvent onSuperChat;

    string chatID;
    public bool IsAvailableId { get; private set; } = false;

    private void Start()
    {
        if(this.playOnAwake)
        {
            BeginGetComments();
        }
    }

    /// <summary>
    /// コメント取得を開始する
    /// </summary>
    public void BeginGetComments()
    {
        StartCoroutine(BeginGetCommentSimple());
    }

    public bool TryGetChatId(string videoId)
    {
        StartCoroutine(GetChatID(videoId));
        return IsAvailableId;
    }

    IEnumerator BeginGetCommentSimple()
    {
        if(string.IsNullOrEmpty(this.APIKEY))
        {
            Debug.LogError("Please Input APIKEY");
            yield break;
        }

        if(string.IsNullOrEmpty(this.VideoID))
        {
            Debug.LogError("Please Input VideoID");
            yield break;
        }

        if (IsAvailableId)
        {
            yield return GetComments();
        }
        else
        {
            Debug.LogError("先にTryGetChatIdを実行してね！まだChatIdは使えないよ！");
            yield break;
        }
    }
    
    IEnumerator GetChatID(string videoId)
    {
        var url = $"https://www.googleapis.com/youtube/v3/videos?id={videoId}&key={this.APIKEY}&part=liveStreamingDetails";

        using (var req = UnityWebRequest.Get(url))
        {
            yield return req.SendWebRequest();
            var json = SimpleJSON.JSON.Parse(req.downloadHandler.text);
            this.chatID = json["items"][0]["liveStreamingDetails"]["activeLiveChatId"].ToString();
             if (string.IsNullOrEmpty(this.chatID))
            {
                Debug.LogError("activeLiveChatId not found.");
                IsAvailableId = false;
                yield break;
            }
        }
        this.chatID = chatID.Replace("\"", "");
        IsAvailableId = true;
        Debug.Log("ChatID=" + this.chatID);
    }

    
    System.DateTime latestSuperChat = new System.DateTime();
    System.DateTime latestComment = new System.DateTime();

    IEnumerator GetComments()
    {
        var commentURL = $"https://www.googleapis.com/youtube/v3/liveChat/messages?liveChatId={this.chatID}&key={this.APIKEY}&maxResults=2000&part=authorDetails,snippet";

        while (true)
        {
            using (var req = UnityWebRequest.Get(commentURL))
            {
                yield return req.SendWebRequest();

                if (req.isNetworkError || req.isHttpError)
                {
                    continue;
                }
                var data = SimpleJSON.JSON.Parse(req.downloadHandler.text);

                var items = data["items"];
                var commentList = new List<Comment>();
                for (int i = 0; i < items.Count; i++)
                {
                    var id = items[i]["id"];
                    var snippet = items[i]["snippet"];
                    var author = items[i]["authorDetails"];
                    var displayName = author["displayName"];
                    var icon = author["profileImageUrl"];
                    var dTime = System.DateTime.Parse(snippet["publishedAt"]);
                    var message = snippet["displayMessage"];

                    var comment = new Comment()
                    {
                        ID = id,
                        TimeStamp = dTime,
                        AuthorName = displayName,
                        Icon = icon,
                        Message = message
                    };

                    if( dTime > this.latestComment)
                    {
                        commentList.Add(comment);
                        this.latestComment = dTime;
                    }

                    if (snippet["type"].ToString().Contains("superChatEvent"))
                    {
                        if( dTime > this.latestSuperChat)
                        {
                            var superChatDetails = snippet["superChatDetails"];
                            comment.AmountDisplay = superChatDetails["amountDisplayString"];
                            comment.AmountMicros = superChatDetails["amountMicros"];
                            comment.SuperChatComment = superChatDetails["userComment"];

                            onSuperChat?.Invoke(comment);

                            this.latestSuperChat = dTime;
                        }

                    }
                }

                if(commentList.Count > 0)
                {
                    onComment?.Invoke(commentList);
                }
            }

            yield return new WaitForSeconds(this.GetCommentInterval);
        }
    }
}
