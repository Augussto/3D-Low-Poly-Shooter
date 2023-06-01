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
        if (Input.GetKeyDown(KeyCode.P))
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
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        Panel.SetActive(false);
        Time.timeScale = 1f;
        JuegoPausado = false;
    }
    public void Pausar()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        Panel.SetActive(true);
        Time.timeScale = 0f;
        JuegoPausado = true;
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
