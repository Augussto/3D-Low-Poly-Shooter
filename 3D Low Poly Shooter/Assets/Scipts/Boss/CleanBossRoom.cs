using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CleanBossRoom : MonoBehaviour
{
    [SerializeField] private DontDestroyOnLoad[] listOfDestroyObjects;
    // Start is called before the first frame update
    void Awake()
    {
        listOfDestroyObjects = FindObjectsOfType<DontDestroyOnLoad>();
        if (listOfDestroyObjects != null)
        {
            for (int i = 0; i < listOfDestroyObjects.Length; i++)
            {
                if (listOfDestroyObjects[i].ID != "0")
                {
                    Destroy(listOfDestroyObjects[i].gameObject);
                }
            }
        }
    }
}
