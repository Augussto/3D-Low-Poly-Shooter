using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class BasicEnemyAI : MonoBehaviour
{
    public Transform player;

    public float speed;
    public float life;
    private float start_life;
    public Rigidbody rb;

    public float maxDist = 10;
    public float minDist = 2;

    public WeaponSystem ws;

    public Image healthBar;

    private NavMeshAgent navMeshAgent;

    private void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        player = FindObjectOfType<PlayerMotor>().GetComponent<Transform>();
        ws = FindObjectOfType<WeaponSystem>();
        rb = GetComponent<Rigidbody>();
        start_life = 10;
        life = start_life;
    }

    void Update()
    {
        transform.LookAt(player);
        navMeshAgent.destination = player.transform.position;
        //if (Vector3.Distance(transform.position, player.position) >= minDist)
        //{
        //    rb.MovePosition(rb.position + transform.forward * speed * Time.deltaTime);
        //}

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
            healthBar.fillAmount = life/start_life;
            Debug.Log("Enemy Life: " + life);
        }
    }

}
