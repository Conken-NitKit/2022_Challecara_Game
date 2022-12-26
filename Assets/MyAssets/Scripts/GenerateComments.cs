using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



/// <summary>
/// コメントの性質を表す基底クラス
/// <summary>
public class CommentsNature : MonoBehaviour{
    
    public float commentSpeed = 500.0f;

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

    public GameObject oneLineStraightAttackComment_TextPrefab; //1直線
    public GameObject threeLineStraighAttackComment_TextPrefab; //3方向に直進
    public GameObject halfCircleAttackComment_TextPrefab; //5文字のコメントを半円状に

    private OneLineStraightAttackComment oneLineStraightAttackComment;
    private ThreeLineStraighAttackComment threeLineStraighAttackComment;
    private HalfCircleAttackComment halfCircleAttackComment;

    public GameObject playerObjectPrefab;


    private void Awake()
    {
        oneLineStraightAttackComment =
            oneLineStraightAttackComment_TextPrefab.GetComponent<OneLineStraightAttackComment>();
        threeLineStraighAttackComment =
            threeLineStraighAttackComment_TextPrefab.GetComponent<ThreeLineStraighAttackComment>();
        halfCircleAttackComment = halfCircleAttackComment_TextPrefab.GetComponent<HalfCircleAttackComment>();
    }

    public void StartCoroutineComment(string text)
    {
        StartCoroutine(GetComments(text));
    }

    public IEnumerator GetComments(string comment){
        
        //取得したコメントの半角と全角の空白を消去
        string commentReplaceAfter = comment.Replace(" ","").Replace("　","");
        int commentLength = commentReplaceAfter.Length;

        //取得したコメントを発射する座標であるプレイヤーの座標の取得
        Transform playerTransform = playerObjectPrefab.transform;
        Vector3 playerPos = playerTransform.position;

        /*if(commentLength == 5){

            //5文字に分岐　(30 60 90 120 150)

            //Debug.Log(commentLength + "　→5列");
            Debug.Log("5!!!!!!!!!!");
            //halfCircleAttackComment.Start();

        }else if(commentLength % 3 == 0){

            //３列に分岐 (45 90 135)
            Debug.Log("3!!!!!!!!!!");
            
            //Debug.Log(commentLength + "　→3列");
            threeLineStraighAttackComment.Text = commentReplaceAfter;
            GameObject newTextObj = Instantiate(threeLineStraighAttackComment_TextPrefab, new Vector3(playerPos.x, playerPos.y, playerPos.z), Quaternion.Euler(90, playerTransform.eulerAngles.y, 90)); //インスタンス化


        }else{

            //１列に直行 (90)
            Debug.Log("1!!!!!!!!!!!");

            //Debug.Log(commentLength + "　→1列");
            //oneLineStraightAttackComment.Start();

            //コメントの３DオブジェクトのプレハブにあるTextMeshに入力されたコメントを代入したもののインスタンス化*/
            oneLineStraightAttackComment_TextPrefab.GetComponent<TextMesh>().text = commentReplaceAfter; 
            //oneLineStraightAttackComment.Text = commentReplaceAfter; 
            GameObject newTextObj = Instantiate(oneLineStraightAttackComment_TextPrefab, new Vector3(playerPos.x, 1, playerPos.z), Quaternion.Euler(90, playerTransform.eulerAngles.y, 90)); //インスタンス化
            

        yield return new WaitForSeconds(0.1f);
        commentList.Remove(commentReplaceAfter);
    }
 

}