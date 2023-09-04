using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyOnLoad : MonoBehaviour
{
    private static Dictionary<string, GameObject> _instances = new Dictionary<string, GameObject>();
    public string ID; // Este ID puede ser lo que quieras

    void Awake()
    {
        if (_instances.ContainsKey(ID))
        {
            var existing = _instances[ID];

            if (existing != null)
            {
                if (ReferenceEquals(gameObject, existing))
                    return;

                Destroy(gameObject);

                return;
            }
        }

        _instances[ID] = gameObject;

        DontDestroyOnLoad(gameObject);
    }
}
