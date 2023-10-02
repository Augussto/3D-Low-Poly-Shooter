using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class MageEnemy : MonoBehaviour
{
    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform firingPoint;
    [SerializeField] private float shootForce;
    private float timer;
    private float bulletTime;

    public Transform player;

    public float speed;
    public float life;
    private float start_life;
    public Rigidbody rb;

    public WeaponSystem ws;

    public Image healthBar;

    private NavMeshAgent navMeshAgent;

    private DropOnDeath dod;

    [SerializeField] private ContadorEnemigos contadorEnemigos;
    [SerializeField] private GameManager gm;

    [SerializeField] private float randomBulletsToShoot;

    private void Start()
    {
        timer = 5f;
        shootForce = 1000f;
        gm = FindObjectOfType<GameManager>();
        contadorEnemigos = FindObjectOfType<ContadorEnemigos>();
        navMeshAgent = GetComponent<NavMeshAgent>();
        player = GameObject.Find("Player").GetComponent<Transform>();
        ws = FindObjectOfType<WeaponSystem>();
        rb = GetComponent<Rigidbody>();
        dod = GetComponent<DropOnDeath>();
        if (contadorEnemigos != null)
        {
            contadorEnemigos.AddEnemy();
        }
        start_life = 25;
        life = start_life;
    }

    void Update()
    {
        transform.LookAt(player);
        if (Vector3.Distance(this.transform.position, player.position) < 15f)
        {
            StartCoroutine(ShootPlayer());
        }
        else
        {
            //Chase Player
            navMeshAgent.destination = player.transform.position;
        }


        //Destroy Enemy when life = 0
        if (life <= 0)
        {
            if (gm.totalEnemies != null)
            {
                contadorEnemigos.DeleteEnemy();
                dod.Drop();
                gm.ReloadScene();
            }
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Bullet")
        {
            life -= ws.damage;
            healthBar.fillAmount = life / start_life;
        }
    }

    private IEnumerator ShootPlayer()
    {
        bulletTime -= Time.deltaTime;

        if (bulletTime < 0)
        {
            randomBulletsToShoot = Random.Range(2, 5);

            bulletTime = timer;

            for (int i = 0; i < randomBulletsToShoot; i++)
            {
                GameObject proyectile = Instantiate(bullet, firingPoint.position, firingPoint.transform.rotation);
                Rigidbody rb = proyectile.GetComponent<Rigidbody>();
                rb.AddForce(rb.transform.forward * shootForce);
                yield return new WaitForSeconds(0.2f);
            }
        }    
    }
}
