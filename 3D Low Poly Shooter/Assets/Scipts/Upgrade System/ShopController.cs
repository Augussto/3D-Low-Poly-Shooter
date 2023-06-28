using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopController : MonoBehaviour
{
    [SerializeField] private GameObject pressE;
    [SerializeField] private GameObject panelShop;
    [SerializeField] private bool isInsideCollider;

    private CharacterController ccPlayer;
    // Start is called before the first frame update
    void Start()
    {
        ccPlayer = FindObjectOfType<CharacterController>();
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
                    Cursor.visible = false;
                    Cursor.lockState = CursorLockMode.Locked;
                }
                else
                {
                    panelShop.SetActive(true);
                    pressE.SetActive(false);
                    Cursor.visible = true;
                    Cursor.lockState = CursorLockMode.None;
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
