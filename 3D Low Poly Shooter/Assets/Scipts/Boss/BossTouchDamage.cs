using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossTouchDamage : MonoBehaviour
{
    private PlayerLife playerLife;
    public int damage;
    // Start is called before the first frame update
    void Start()
    {
        playerLife = FindObjectOfType<PlayerLife>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            playerLife.RecieveDamage(damage);
            playerLife.GetComponent<HurtEffect>().HurtPlayer();
        }
    }
}
