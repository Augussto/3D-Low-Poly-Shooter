using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField]private ContadorEnemigos totalEnemies;
    // Start is called before the first frame update
    void Start()
    {
        totalEnemies = FindObjectOfType<ContadorEnemigos>();
    }

    // Update is called once per frame
    void Update()
    {
        if(totalEnemies.GetCantEnemies() > 25)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    public void ReloadScene()
    {
        Debug.Log("Outside Reload Scene");
        if (totalEnemies.GetCantEnemies() == 0)
        {
            Debug.Log("Reload Scene");
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
