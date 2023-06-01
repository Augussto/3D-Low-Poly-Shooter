using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuPausa : MonoBehaviour
{
    public static bool JuegoPausado = false;
    public GameObject Panel;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (JuegoPausado == true)
            {
                Resumir(); 
            }
            else
            {
                Pausar();
            }
        }
    }
    public void Resumir()
    {
        Panel.SetActive(false); 
        Time.timeScale = 1f;
        JuegoPausado = false;
        Debug.Log("Resumir");
    }
    public void Pausar()
    {
        Panel.SetActive(true);
        Time.timeScale = 0f;
        JuegoPausado = true;
        Debug.Log("Pausar");
    }
    public void CargarMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
        Debug.Log("Menu");
    }
    public void Salir()
    {
        Application.Quit();
        Debug.Log("Salir");

    }
}
