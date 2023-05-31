using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetPlayerSpawnpoint : MonoBehaviour
{
    [SerializeField] private CharacterController player;
    [SerializeField] private Transform spawnpoint;
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<CharacterController>();
        spawnpoint = GetComponent<Transform>();
        player.enabled = false;
        Transform playerTransform = player.GetComponent<Transform>();
        playerTransform.position = spawnpoint.position;
        player.enabled = true;
    }

}
