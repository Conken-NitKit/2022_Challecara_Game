using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UserDataChecker : MonoBehaviour
{
   [SerializeField] private InputField nameInputField;
   [SerializeField] private InputField chatIdInputField;
   [SerializeField] private YoutubeComment youtubeComment;

   public bool IsAvailableUserName()
   {
      return string.IsNullOrEmpty(nameInputField.text);
   }
   public bool IsAvailableChatId()
   {
      youtubeComment.TryGetChatId(chatIdInputField.text);
      return youtubeComment.IsAvailableId;
   }
}
