using System.Collections;
using System.Collections.Generic;
using PlayFab.ExperimentationModels;
using UnityEngine;

public class Test : MonoBehaviour
{
    [SerializeField] private string[] texts;
    [SerializeField] private GenerateComments generateComments;

    private void Start()
    {
        foreach (string text in texts)
        {
            generateComments.StartCoroutineComment(text);
        }
    }
}
