using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetDetection : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Bullet")
        {
            gameObject.tag = "Finish";
            Debug.Log("Triggered Target by Bullet");
            Destroy(gameObject);
        }
    }
}
