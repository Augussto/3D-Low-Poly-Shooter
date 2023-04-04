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

    public WeaponSystem ws;

    private void Start()
    {
        ws = FindObjectOfType<WeaponSystem>();
        rb = GetComponent<Rigidbody>();
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

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Bullet")
        {
            Debug.Log("Enemy Take Damage");
            life -= ws.damage;
            Debug.Log("Enemy Life: " + life);
        }
    }

}
