using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropOnDeath : MonoBehaviour
{
    [SerializeField] private GameObject coin;
    private void OnDestroy()
    {
        Instantiate(coin, this.gameObject.transform.position, Quaternion.identity);
    }
}
