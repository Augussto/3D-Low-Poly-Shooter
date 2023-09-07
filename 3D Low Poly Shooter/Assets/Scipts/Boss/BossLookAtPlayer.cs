using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossLookAtPlayer : MonoBehaviour
{
    [SerializeField] Transform player;
    // Update is called once per frame
    void Update()
    {
        transform.LookAt(player);
    }
}
