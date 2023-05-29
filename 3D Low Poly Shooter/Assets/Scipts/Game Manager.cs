using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField]private ContadorEnemigos totalEnemies;
    private DungeonController dg;
    // Start is called before the first frame update
    void Start()
    {
        dg = FindObjectOfType<DungeonController>();
        totalEnemies = FindObjectOfType<ContadorEnemigos>();
    }

    // Update is called once per frame
    void Update()
    {
        if(totalEnemies.GetCantEnemies() > 35)
        {
            totalEnemies.SetEnemies(0f);
            dg.RestDungeonSize();
            ReloadScene();
        }
    }

    public void ReloadScene()
    {
        if (totalEnemies.GetCantEnemies() == 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
