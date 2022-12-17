using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class EnemySpawner : MonoBehaviour
{
    public float SpawnFrequency { get; private set; }
    public Vector3 SpawnRange{ get; set; } 
    public int MaxEnemyCount{ get; set; }
    public EnemyFactory enemyFactory{ get; set; }
    public GameObject prefab;
    private List<GameObject> enemys;
    private Random rand = new Random();
    
    /// <summary>
    /// 初期化処理
    /// </summary>
    /// <param name="maxEnemyCount">敵の生成上限数</param>
    public void Init(int maxEnemyCount,GameObject prefab)
    {
        MaxEnemyCount = maxEnemyCount;
        this.prefab = prefab;
        enemys = new List<GameObject>();
        for (int i = 0; i < MaxEnemyCount; i++)
        {
            GameObject obj = Instantiate(prefab);
            obj.transform.SetParent(gameObject.transform);
            
            GameObject enemy = enemyFactory.Create(obj);
            obj.SetActive(false);
            enemys.Add(enemy);

        }
    }
    /// <summary>
    /// 敵の生成コルーチンを開始するメソッド
    /// </summary>
    /// <param name="spawnFrequency">敵の出現頻度</param>
    public void StartSpawn(float spawnFrequency)
    {
        rand = new Random();
        SpawnFrequency = spawnFrequency;
        StartCoroutine(nameof(SpawnEnemy));
    }
    /// <summary>
    /// 敵の生成コルーチンを停止するメソッド
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
