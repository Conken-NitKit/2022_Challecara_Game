using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/CreateEnemyParams")]
public class EnemyParams : ScriptableObject
    {
        [SerializeField] public string enemyName;

        [SerializeField] public float maxHp;

        [SerializeField] public float atk;
        [SerializeField] public int score;
    }
