using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttacks : MonoBehaviour
{
    private int randAttack;
    public float cooldownAbilities;
    [SerializeField] Animator animator;
    [SerializeField] GameObject player;
    [SerializeField] GameObject bullet;
    [SerializeField] Transform firingPoint, handL, handR;
    [SerializeField] float shootForce;
    [SerializeField] GameObject enemy01, enemy02, enemy03;
    [SerializeField] Animator bossAnimator;
    [SerializeField] GameObject damageArea;
    [SerializeField] ParticleSystem particlesDamageArea;
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerLife>().gameObject;
        StartCoroutine(CooldownAttack());
        cooldownAbilities = 5f;
    }

    IEnumerator CooldownAttack()
    {
        yield return new WaitForSeconds(cooldownAbilities);
        randAttack = Random.Range(1,5);
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
        bossAnimator.SetBool("Attack01", true);
        for (int i = 0; i < 20; i++)
        {
            GameObject proyectile = Instantiate(bullet, firingPoint.position, firingPoint.transform.rotation);
            proyectile.transform.localScale = new Vector3(1f, 1f, 1f);
            Rigidbody rb = proyectile.GetComponent<Rigidbody>();
            rb.AddForce(rb.transform.forward * shootForce);
            yield return new WaitForSeconds(0.2f);
        }
        bossAnimator.SetBool("Attack01", false);
        StartCoroutine(CooldownAttack());
    }
    IEnumerator Attack02()
    {
        yield return new WaitForSeconds(1f);
        bossAnimator.SetTrigger("Attack02");
        Instantiate(enemy01, handL.position, firingPoint.transform.rotation);
        Instantiate(enemy02, handR.position, firingPoint.transform.rotation);
        Instantiate(enemy03, firingPoint.position, firingPoint.transform.rotation);
        Debug.Log("Attack 02");
        StartCoroutine(CooldownAttack());
    }
    IEnumerator Attack03()
    {
        yield return new WaitForSeconds(1f);
        bossAnimator.SetTrigger("Attack03");
        yield return new WaitForSeconds(1f);
        damageArea.SetActive(true);
        particlesDamageArea.Play();
        yield return new WaitForSeconds(1f);
        damageArea.SetActive(false);
        StartCoroutine(CooldownAttack());
    }
    IEnumerator Attack04()
    {
        yield return new WaitForSeconds(1f);
        Debug.Log("Attack 04");
        bossAnimator.SetTrigger("Attack04");
        StartCoroutine(CooldownAttack());
    }
}
