using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttacks : MonoBehaviour
{
    private int randAttack;
    [SerializeField] Animator animator;
    [SerializeField] GameObject player;
    [SerializeField] GameObject bullet;
    [SerializeField] Transform firingPoint, handL, handR;
    [SerializeField] float shootForce;
    [SerializeField] GameObject enemy01, enemy02, enemy03;
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerLife>().gameObject;
        StartCoroutine(CooldownAttack());
    }

    IEnumerator CooldownAttack()
    {
        yield return new WaitForSeconds(5f);
        randAttack = Random.Range(1,4);
        switch (randAttack)
        {
            case 1:
                StartCoroutine(Attack01());
                break;
            case 2:
                StartCoroutine(Attack02());
                break;
            case 3:
                StartCoroutine(Attack03());
                break;
            case 4:
                StartCoroutine(Attack04());
                break;
        }

    }

    IEnumerator Attack01()
    {
        yield return new WaitForSeconds(1f);
        for (int i = 0; i < 20; i++)
        {
            GameObject proyectile = Instantiate(bullet, firingPoint.position, firingPoint.transform.rotation);
            proyectile.transform.localScale = new Vector3(1f, 1f, 1f);
            Rigidbody rb = proyectile.GetComponent<Rigidbody>();
            rb.AddForce(rb.transform.forward * shootForce);
            yield return new WaitForSeconds(0.2f);
        }
        Debug.Log("Attack 01");
        StartCoroutine(CooldownAttack());
    }
    IEnumerator Attack02()
    {
        yield return new WaitForSeconds(1f);
        Instantiate(enemy01, handL.position, firingPoint.transform.rotation);
        Instantiate(enemy02, handR.position, firingPoint.transform.rotation);
        Instantiate(enemy03, firingPoint.position, firingPoint.transform.rotation);
        Debug.Log("Attack 02");
        StartCoroutine(CooldownAttack());
    }
    IEnumerator Attack03()
    {
        yield return new WaitForSeconds(1f);
        Debug.Log("Attack 03");
        StartCoroutine(CooldownAttack());
    }
    IEnumerator Attack04()
    {
        yield return new WaitForSeconds(1f);
        Debug.Log("Attack 04");
        StartCoroutine(CooldownAttack());
    }
}
