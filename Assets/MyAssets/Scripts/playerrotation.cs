using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerrotation : MonoBehaviour
{
    //[SerializeField] private float speed;
    private Vector3 Player_pos; //プレイヤーのポジション
    private float x; //x方向のImputの値
    private float y; //z方向のInputの値
    //private float z; 
    private Rigidbody rigd;

    void Start()
    {
        Player_pos = GetComponent<Transform>().position; //最初の時点でのプレイヤーのポジションを取得
        rigd = GetComponent<Rigidbody>(); //プレイヤーのRigidbodyを取得
    }

    void Update()
    {

        x = Input.GetAxis("Horizontal"); //x方向のInputの値を取得
        y = Input.GetAxis("Vertical"); //y方向のInputの値を取得
        //z = 0.0f;

        //rigd.velocity = new Vector3(x * speed, 0, z * speed); //プレイヤーのRigidbodyに対してInputにspeedを掛けた値で更新し移動

        Vector3 diff = transform.position - Player_pos; //プレイヤーがどの方向に進んでいるかがわかるように、初期位置と現在地の座標差分を取得

        if (diff.magnitude > 0.01f) //ベクトルの長さが0.01fより大きい場合にプレイヤーの向きを変える処理を入れる(0では入れないので）
        {
            transform.rotation = Quaternion.LookRotation(diff);  //ベクトルの情報をQuaternion.LookRotationに引き渡し回転量を取得しプレイヤーを回転させる
        }

        //Player_pos = transform.position; //プレイヤーの位置を更新


    }
}
