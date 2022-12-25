using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class DemoAttack : MonoBehaviour
{
    [SerializeField] private GenerateComments generateComments;
    [SerializeField] private string[] demoComments;
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            int rnd = Random.Range(0,demoComments.Length);
            generateComments.StartCoroutineComment(demoComments[rnd]);
        }
    }
}
