using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCollider : MonoBehaviour
{
    [SerializeField]
    private float bulletAtk;
    
    private void OnTriggerEnter(Collider collider)
    {
        Debug.Log(collider.name);
        if (collider.CompareTag("Enemy"))
        {
            collider.GetComponent<Enemy>()
                .AddedDamage(GameObject.FindWithTag("Player").GetComponent<PlayerStatus>().nowPlayerAtk * bulletAtk);
        }
    }
}
