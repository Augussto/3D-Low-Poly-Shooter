using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinController : MonoBehaviour
{
    [SerializeField] private CoinCounter cc;
    // Start is called before the first frame update
    void Start()
    {
        cc = FindObjectOfType<CoinCounter>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            cc.AddCoin();
            Destroy(this.gameObject);
        }
    }
}
