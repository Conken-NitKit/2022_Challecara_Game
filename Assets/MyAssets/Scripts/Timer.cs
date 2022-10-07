using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UniRx;

public class Timer : MonoBehaviour
{
    public ReactiveProperty<float> nowTimer { get; private set; } = new ReactiveProperty<float>();

    //多分GameManagerクラスにうつす
    private bool isGameOver = false;

    [SerializeField]
    private Text timerText;
    

    public void StartCountUp()
    {
        nowTimer.Value = 0f;
        
        var subscription = nowTimer.Subscribe(x =>
        {
            timerText.text = $"Time :{nowTimer.Value : 000.0}";
        });

        StartCoroutine(CountUpTime());
    }

    private IEnumerator CountUpTime()
    {
        while (!isGameOver)
        {
            yield return new WaitForSeconds(0.1f);
            nowTimer.Value += 0.1f;
        }
    }
}
