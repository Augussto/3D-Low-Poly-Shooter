using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HostileProyectile : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private float damage;
    [SerializeField] private PlayerLife pl;
    

    // Start is called before the first frame update
    void Start()
    {
        Destroy(this.gameObject, 2f);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            pl = FindObjectOfType<PlayerLife>();
            pl.GetComponent<HurtEffect>().HurtPlayer();
            pl.RecieveDamage(damage);
        }
        Destroy(this.gameObject);
    }
}
