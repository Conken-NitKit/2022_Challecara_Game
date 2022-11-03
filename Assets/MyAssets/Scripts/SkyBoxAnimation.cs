using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyBoxAnimation : MonoBehaviour 
{
    [SerializeField]
    private float rotateSpeed = 0.1f;
    
    private Material _skyboxMaterial;

    void Start () {
        _skyboxMaterial = RenderSettings.skybox;
    }
	
    void Update () {
        //　スカイボックスマテリアルのRotationを操作して角度を変化させる
        //SetFloatでMaterialの値を変更、Mathf.Repeatは規定値までいくと0に戻るメソッド
        _skyboxMaterial.SetFloat("_Rotation", Mathf.Repeat(_skyboxMaterial.GetFloat("_Rotation") + rotateSpeed * Time.deltaTime, 360f));
    }
}