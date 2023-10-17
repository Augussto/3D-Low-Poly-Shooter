using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinController : MonoBehaviour
{
    [SerializeField] private CoinCounter cc;
    [SerializeField] private AudioSource audio;
    // Start is called before the first frame update
    void Start()
    {
        cc = FindObjectOfType<CoinCounter>();
        audio = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            audio.Play();
            cc.AddCoin();
            Destroy(this.gameObject,0.5f);
        }
    }
}
