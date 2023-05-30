using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private ContadorEnemigos totalEnemies;
    [SerializeField] private Transform player;
    private DungeonController dg;
    private UIController uic;
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerLife>().GetComponent<Transform>();
        dg = FindObjectOfType<DungeonController>();
        totalEnemies = FindObjectOfType<ContadorEnemigos>();
        uic = FindObjectOfType<UIController>();
    }

    // Update is called once per frame
    void Update()
    {
        if(totalEnemies == null)
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

    public void ReloadScene()
    {
        if (totalEnemies.GetCantEnemies() == 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            StartCoroutine(uic.LoadingPanel());
            player.position = new Vector3(0, 25, 0);
        }
    }
}
