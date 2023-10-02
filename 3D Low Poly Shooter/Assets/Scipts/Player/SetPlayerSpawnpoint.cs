using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetPlayerSpawnpoint : MonoBehaviour
{
    [SerializeField] private CharacterController player;
    [SerializeField] private Transform spawnpoint;
    [SerializeField] private GameObject standPlatform;
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<CharacterController>();
        spawnpoint = GetComponent<Transform>();
        player.enabled = false;
        Transform playerTransform = player.GetComponent<Transform>();
        playerTransform.position = spawnpoint.position;
        player.enabled = true;
        StartCoroutine(HidePlatform());
    }

    IEnumerator HidePlatform()
    {
        yield return new WaitForSeconds(5f);
        standPlatform.SetActive(false);
    }

}
