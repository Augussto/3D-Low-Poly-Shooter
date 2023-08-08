using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MageEnemy : MonoBehaviour
{
    [SerializeField] private GameObject[] spikes;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        foreach (GameObject spike in spikes)
        {
            spike.SetActive(true);
        }
        StartCoroutine(HideSpikes());
    }

    IEnumerator HideSpikes()
    {
        yield return new WaitForSeconds(3f);

        foreach (GameObject spike in spikes)
        {
            spike.SetActive(false);
        }
    }
}
