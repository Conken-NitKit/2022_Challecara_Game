using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// スカイボックスのアニメーションクラスです
/// </summary>
public class SkyBoxAnimation : MonoBehaviour 
{
    [SerializeField]
    private float rotateSpeed = 0.1f;
    
    private Material _skyboxMaterial;

    // 最大の角度、変更することないと思うので定数化
    private const float MaxAngle = 360f;

    void Start () {
        _skyboxMaterial = RenderSettings.skybox;
    }
	
    void Update () {
        // スカイボックスマテリアルのRotationを操作して角度を変化させる
        // SetFloatでMaterialの値を変更、Mathf.Repeatは規定値までいくと0に戻るメソッド
        _skyboxMaterial.SetFloat("_Rotation", Mathf.Repeat(_skyboxMaterial.GetFloat("_Rotation") + rotateSpeed * Time.deltaTime, MaxAngle));
    }
}