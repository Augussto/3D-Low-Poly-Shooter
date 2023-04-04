using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    private WeaponSystem ws;
    private BasicEnemyAI enemyAI;

    // Start is called before the first frame update
    void Start()
    {
        ws = GetComponent<WeaponSystem>();
        enemyAI = GetComponent<BasicEnemyAI>();
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Deal Damage to Player");
        }
        
    }
}
