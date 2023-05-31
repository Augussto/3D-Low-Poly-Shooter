using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeSpawner : MonoBehaviour
{
    [SerializeField] private GameObject cubePrefab;
    [SerializeField] private GameObject currentCubeOnMap;
    [SerializeField] private Transform player;
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<CharacterController>().GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if(currentCubeOnMap == null)
            {
                currentCubeOnMap = Instantiate(cubePrefab, new Vector3(player.position.x,player.position.y + 1f,player.position.z), Quaternion.identity);
            }
            else
            {
                Destroy(currentCubeOnMap);
                currentCubeOnMap = Instantiate(cubePrefab, new Vector3(player.position.x, player.position.y + 1f, player.position.z), Quaternion.identity);
            }
        }
    }
}
