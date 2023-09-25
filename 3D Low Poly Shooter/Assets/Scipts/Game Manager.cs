using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public ContadorEnemigos totalEnemies;
    [SerializeField] private Transform player;
    private DungeonController dg;
    private UIController uic;
    // Start is called before the first frame update
    void Start()
    {
        if(SceneManager.GetActiveScene().name != "Boss01 Room")
        {
            dg = FindObjectOfType<DungeonController>();
            totalEnemies = FindObjectOfType<ContadorEnemigos>();
            uic = FindObjectOfType<UIController>();
            player = FindObjectOfType<CharacterController>().GetComponent<Transform>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name != "Boss01 Room")
        {
            if (totalEnemies == null)
            {
                totalEnemies = FindObjectOfType<ContadorEnemigos>();
            }
            if(dg == null)
            {
                dg = FindObjectOfType<DungeonController>();
            }
            if(totalEnemies.GetCantEnemies() > 35)
            {
                totalEnemies.SetEnemies(0f);
                dg.RestDungeonSize();
                ReloadScene();
            }
        }
            
        if (player.position.y < -20)
        {
            ReturnToHub();
        }
    }

    public void ReloadScene()
    {
        if (totalEnemies.GetCantEnemies() == 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            StartCoroutine(uic.LoadingPanel());
        }

        if(player.position.y < -20)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            StartCoroutine(uic.LoadingPanel());
        }
    }

    public void ReturnToMenu()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        totalEnemies.SetEnemies(0);
        SceneManager.LoadScene("Menu");
    }

    public void ReturnToHub()
    {
        if (SceneManager.GetActiveScene().name != "Boss01 Room")
        {
            totalEnemies.SetEnemies(0);
        }   
        SceneManager.LoadScene("Escena Augusto Test");
    }
}
