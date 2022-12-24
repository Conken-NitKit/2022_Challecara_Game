using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using Random = System.Random;

/// <summary>
/// 敵のスポナークラス
/// </summary>
public class EnemySpawner : MonoBehaviour
{
    public float SpawnFrequency { get; private set; }
    public Vector3 SpawnRange{ get; set; } 
    public int MaxEnemyCount{ get; set; }
    public List<GameObject> enemys = new List<GameObject>();
    public IObservable<Enemy> OnEnemyCreated
    {
        get { return enemySubject; }
    } 
    
    private Subject<Enemy> enemySubject = new Subject<Enemy>();
    
    private EnemyFactory enemyFactory;
    private GameObject prefab;
    private Random rand = new Random();

    /// <summary>
    /// 初期化処理
    /// </summary>
    /// <param name="maxEnemyCount">Enemyの生成上限数</param>
    /// <param name="prefab">生成するEnemyのObject</param>
    /// <param name="enemyFactory">生成するEnemyのFactoryクラス</param>
    public void Init(int maxEnemyCount,GameObject prefab,EnemyFactory enemyFactory)
    {
        MaxEnemyCount = maxEnemyCount;
        this.enemyFactory = enemyFactory;
        this.prefab = prefab;
        
        for (int i = 0; i < MaxEnemyCount; i++)
        {
            Debug.Log($"EnemyCount{MaxEnemyCount}");
            GameObject obj = Instantiate(prefab);
            obj.transform.SetParent(gameObject.transform);
            
            Debug.Log(enemyFactory);
            GameObject enemy = enemyFactory.Create(obj);
            enemySubject.OnNext(enemy.GetComponent<Enemy>());
            obj.SetActive(false);
            enemys.Add(enemy);
        }
    }

    /// <summary>
    /// Enemyの生成上限を増やすメソッド
    /// </summary>
    /// <param name="increaseNum">増やしたいEnemyの生成上限数</param>

    public void IncreaseMaxCount(int increaseNum)
    {
        if (increaseNum <= 0){return;}
        MaxEnemyCount += increaseNum;
        for (int i = 0; i < increaseNum; i++)
        {
            GameObject obj = Instantiate(prefab, gameObject.transform, true);
            GameObject enemy = enemyFactory.Create(obj);
            enemySubject.OnNext(enemy.GetComponent<Enemy>());
            obj.SetActive(false);
            enemys.Add(enemy);
        }
    }

    /// <summary>
    /// Enemyの生成コルーチンを開始するメソッド
    /// </summary>
    /// <param name="spawnFrequency">Enemyの出現頻度</param>
    public void StartSpawn(float spawnFrequency)
    {
        rand = new Random();
        SpawnFrequency = spawnFrequency;
        StartCoroutine(nameof(SpawnEnemy));
    }
    /// <summary>
    /// Enemyの生成コルーチンを停止するメソッド
    /// </summary>
    public void StopSpawn()
    {
        StopCoroutine(nameof(SpawnEnemy));
    }

    private IEnumerator SpawnEnemy()
    {
        while (true)
        {
            Vector3 spawnPos = CalcSpawnPos();
            
            Instantiate(spawnPos);
            
            yield return new WaitForSeconds(SpawnFrequency);
        }
    }
    
    private void Instantiate(Vector3 spawnPos)
    {
        GameObject findObj = enemys.Find(obj => !obj.activeInHierarchy);
        if (findObj == null)
        {
            return;
        }

        findObj.GetComponent<Transform>().position = spawnPos;
        findObj.GetComponent<Enemy>().Init();
    }
    
    private Vector3 CalcSpawnPos()
    {
        while (true)
        {
            Vector2 spawnVector2 = new Vector2();
            if (rand.NextDouble() > 0.5)
            {
                double offset = SpawnRange.x * rand.NextDouble();
                if (rand.NextDouble() > 0.5)
                {
                    spawnVector2.x = (float) offset * -1;
                }else
                {
                    spawnVector2.x = (float) offset + 1;
                }

                spawnVector2.y = (float) rand.NextDouble() * (SpawnRange.y * 2 + 1) - SpawnRange.y;
            }
            else
            {
                double offset = SpawnRange.x * rand.NextDouble();
                if (rand.NextDouble() > 0.5)
                {
                    spawnVector2.y = (float) offset * -1;
                }else
                {
                    spawnVector2.y = (float) offset + 1;
                }
                spawnVector2.x = (float) rand.NextDouble() * (SpawnRange.x * 2 + 1) - SpawnRange.x;
            }

            Ray ray = Camera.main.ViewportPointToRay(new Vector3( spawnVector2.x , spawnVector2.y ,0));
        
            if (Physics.Raycast(ray,out RaycastHit hit))
            {
                return hit.point;
            }
        }
    }
}
