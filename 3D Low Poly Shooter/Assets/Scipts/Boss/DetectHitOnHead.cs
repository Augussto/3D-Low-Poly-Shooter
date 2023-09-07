using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectHitOnHead : MonoBehaviour
{
    [SerializeField] BossController bossController;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Bullet")
        {
            bossController.RecieveDamage();
        }
    }

}
