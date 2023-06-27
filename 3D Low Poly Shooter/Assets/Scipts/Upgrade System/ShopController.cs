using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopController : MonoBehaviour
{
    [SerializeField] private GameObject pressE;
    [SerializeField] private GameObject panelShop;
    [SerializeField] private bool isInsideCollider;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isInsideCollider)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (panelShop.activeSelf)
                {
                    panelShop.SetActive(false);
                    pressE.SetActive(true);
                }
                else
                {
                    panelShop.SetActive(true);
                    pressE.SetActive(false);
                }
            }
        }
        else
        {
            panelShop.SetActive(false);
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        isInsideCollider = true;
        pressE.SetActive(true);
    }

    private void OnTriggerExit(Collider other)
    {
        isInsideCollider = false;
        pressE.SetActive(false);
    }
}
