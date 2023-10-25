using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreEnterBossRoom : MonoBehaviour
{
    [SerializeField] private GameObject textDoor;
    private RunInfo runInfo;
    // Start is called before the first frame update
    void Start()
    {
        runInfo = FindObjectOfType<RunInfo>();
        try
        {
            if (runInfo.passMiniGame01)
            {
                OpenDoor(true);
            }
        }
        catch
        {
            OpenDoor(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OpenDoor(bool open)
    {
        if(open)
        {
            this.gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        textDoor.SetActive(true);
    }
    private void OnTriggerExit(Collider other)
    {
        textDoor.SetActive(false);
    }
}
