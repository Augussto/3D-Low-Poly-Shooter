using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CleanDontDestroyOnLoad : MonoBehaviour
{
    
    [SerializeField]    private DontDestroyOnLoad[] listOfDestroyObjects;
    // Start is called before the first frame update
    void Start()
    {
        listOfDestroyObjects = FindObjectsOfType<DontDestroyOnLoad>();
        if(listOfDestroyObjects != null)
        {
            for(int i = 0; i < listOfDestroyObjects.Length; i++)
            {
                if (listOfDestroyObjects[i].ID != "runinfo")
                {
                    Destroy(listOfDestroyObjects[i].gameObject);
                }
            }
        }
    }
}
