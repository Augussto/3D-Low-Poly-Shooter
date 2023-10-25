using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuPausa : MonoBehaviour
{
    public static bool JuegoPausado = false;
    public GameObject menuPausaUI;
    private GameManager gm;

    //Radio
    [Header("Radio")]
    public GameObject item01, item02, item03;
    private void Start()
    {
        gm = FindObjectOfType<GameManager>();
    }
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
        Debug.Log("Resumir");
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        menuPausaUI.SetActive(false);
        item01.SetActive(false);
        item02.SetActive(false);
        item03.SetActive(false);
        Time.timeScale = 1f;
        JuegoPausado = false;
    }
    void Pausar()
    {
        Debug.Log("Pause");
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        menuPausaUI.SetActive(true);
        item01.SetActive(true);
        item02.SetActive(true);
        item03.SetActive(true);
        Time.timeScale = 0f;
        JuegoPausado = true;
    }
    public void CargarMenu()
    {
        Time.timeScale = 1f;
        gm.ReturnToMenu();
        //SceneManager.LoadScene("Menu");
        Debug.Log("Menu");
    }
    public void Salir()
    {
        Application.Quit();
        Debug.Log("Salir");
    }
}
