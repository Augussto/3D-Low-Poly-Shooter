using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    private void OnTriggerEnter(Collider collision)
    {
        if(collision.tag == "Default")
        {
            Destroy(collision.gameObject);
        }
    }
    
}
