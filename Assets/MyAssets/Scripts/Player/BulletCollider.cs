using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCollider : MonoBehaviour
{
    [SerializeField]
    private float bulletAtk;
    
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Enemy"))
        {
            Debug.Log(GameObject.FindWithTag("Player").GetComponent<PlayerStatus>().nowPlayerAtk);
            collider.GetComponent<Enemy>()
                .AddedDamage(GameObject.FindWithTag("Player").GetComponent<PlayerStatus>().nowPlayerAtk * bulletAtk);
        }
    }
}
