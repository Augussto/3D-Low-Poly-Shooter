using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSpawner : MonoBehaviour
{
    public int openingDirection;
    // 1 need bottom door
    // 2 need top door
    // 3 need left door
    // 4 need right door

    private RoomTemplates templates;
    private int rand;
    private bool spawned;

    private DungeonController dg;

    private void Start()
    {
        dg = FindObjectOfType<DungeonController>();
        templates = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomTemplates>();
        Invoke("Spawn", 0.2f);
    }

    // Update is called once per frame
    private void Spawn()
    {
        if (!spawned)
        {
            if (openingDirection == 1)
            {
                
                if(dg.GetDungeonCurrentSize() == dg.GetDungeonMaxSize())
                {
                    Instantiate(templates.closeRoom, new Vector3(transform.position.x, 0, transform.position.z), Quaternion.identity);
                    Destroy(this.gameObject);
                }
                else
                {
                    rand = Random.Range(0, templates.bottomRooms.Length);
                    Instantiate(templates.bottomRooms[rand], new Vector3(transform.position.x, 0, transform.position.z), Quaternion.identity);
                    dg.CountCurrentDungeon();
                    Destroy(this.gameObject);
                }
            }
            else if (openingDirection == 2)
            {
                
                if (dg.GetDungeonCurrentSize() == dg.GetDungeonMaxSize())
                {
                    Instantiate(templates.closeRoom, new Vector3(transform.position.x, 0, transform.position.z), Quaternion.identity);
                    Destroy(this.gameObject);
                }
                else
                {
                    rand = Random.Range(0, templates.topRooms.Length);
                    Instantiate(templates.topRooms[rand], new Vector3(transform.position.x, 0, transform.position.z), Quaternion.identity);
                    dg.CountCurrentDungeon();
                    Destroy(this.gameObject);
                }
            }
            else if (openingDirection == 3)
            {
                
                if (dg.GetDungeonCurrentSize() == dg.GetDungeonMaxSize())
                {
                    Instantiate(templates.closeRoom, new Vector3(transform.position.x, 0, transform.position.z), Quaternion.identity);
                    Destroy(this.gameObject);
                }
                else
                {
                    rand = Random.Range(0, templates.leftRooms.Length);
                    Instantiate(templates.leftRooms[rand], new Vector3(transform.position.x, 0, transform.position.z), Quaternion.identity);
                    dg.CountCurrentDungeon();
                    Destroy(this.gameObject);
                }
            }
            else if (openingDirection == 4)
            {
                
                if (dg.GetDungeonCurrentSize() == dg.GetDungeonMaxSize())
                {
                    Instantiate(templates.closeRoom, new Vector3(transform.position.x, 0, transform.position.z), Quaternion.identity);
                    Destroy(this.gameObject);
                }
                else
                {
                    rand = Random.Range(0, templates.rightRooms.Length);
                    Instantiate(templates.rightRooms[rand], new Vector3(transform.position.x, 0, transform.position.z), Quaternion.identity);
                    dg.CountCurrentDungeon();
                    Destroy(this.gameObject);
                }
            }
            spawned = true;
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("SpawnPoint"))
        {
            try
            {
                if (collision.GetComponent<RoomSpawner>().spawned == false && spawned == false)
                {
                    Instantiate(templates.closeRoom, new Vector3(transform.position.x, 0, transform.position.z), Quaternion.identity);
                    Destroy(gameObject);
                }
            }
            catch
            {
                Debug.Log("Null Reference Exception");
            }

            spawned = true;

            Destroy(gameObject);
        }
    }
}
