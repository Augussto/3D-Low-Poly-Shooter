using System.Collections;
using System.Collections.Generic;
using Unity.AI.Navigation;
using UnityEngine;

public class DetectSurface : MonoBehaviour
{
    private NavMeshSurface[] navMeshSurface;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DoNav());
    }

    IEnumerator DoNav()
    {
        yield return new WaitForSeconds(4.5f);
        navMeshSurface = FindObjectsOfType<NavMeshSurface>();
        for (int i = 0; i < navMeshSurface.Length; i++)
        {
            navMeshSurface[i].BuildNavMesh();
        }
    }
}
