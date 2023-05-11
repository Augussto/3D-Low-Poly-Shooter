using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject[] enemies;
   
    private int rand;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnEnemy());
    }

    IEnumerator SpawnEnemy()
    {
        yield return new WaitForSeconds(5f);
        rand = Random.Range(0, enemies.Length);
        Instantiate(enemies[rand], transform.position, Quaternion.identity);
    }
}
