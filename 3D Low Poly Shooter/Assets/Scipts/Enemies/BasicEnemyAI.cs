using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemyAI : MonoBehaviour
{
    public Transform player;

    public float speed;
    public float life;
    public Rigidbody rb;

    public float maxDist = 10;
    public float minDist = 2;

    private WeaponSystem ws;

    

    private void Start()
    {
        ws = GetComponent<WeaponSystem>();
    }

    void Update()
    {
        transform.LookAt(player);

        if (Vector3.Distance(transform.position, player.position) >= minDist)
        {
            transform.position += transform.forward * speed * Time.deltaTime;
        }

        //Destroy Enemy when life = 0
        if(life <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Debug.Log("Deal Damage to Player");
        }
        else if(collision.gameObject.tag == "Bullet")
        {
            life -= ws.damage;
            Debug.Log("Enemy Life: " + life);
        }
    }
    
}
