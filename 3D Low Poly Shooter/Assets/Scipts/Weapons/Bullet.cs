using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(this.gameObject, 2f);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(this.gameObject);
    }



}
