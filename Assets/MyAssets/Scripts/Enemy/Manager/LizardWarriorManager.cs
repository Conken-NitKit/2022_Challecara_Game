using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyScript.Scene;

/// <summary>
/// LizardWarriorの処理を発火させるクラス
/// </summary>
public class LizardWarriorManager : MonoBehaviour
{
    [SerializeField] 
    private EnemySpawner _enemySpawner;
    [SerializeField] 
    private GameObject _enemyPref;

    [SerializeField]
    private int maxEnemyCount;
    
    [SerializeField] 
    private Main main;
    
    private int increaseNum;
    
    public void Init()
    {
        _enemySpawner.Init(maxEnemyCount, _enemyPref, new LizardWarriorFactory());
        _enemySpawner.StartSpawn(1f);
        increaseNum = (int)main.battleLevel;
        StartCoroutine(IncreaseEnemySpawn());
    }

    /// <summary>
    /// 敵の出現個数を増やす処理です
    /// </summary>
    IEnumerator IncreaseEnemySpawn()
    {
        while (true)
        {
            yield return new WaitForSeconds(30);
            _enemySpawner.IncreaseMaxCount(increaseNum);
        }
    }
}
