using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;

public class BotonSonido : MonoBehaviour
{

    public static Canvas CanvasMenu;
    public static Canvas CanvasSonido;

    void Start()
    {
        CanvasMenu = CanvasMenu.GetComponent<Canvas>();
        CanvasSonido = CanvasSonido.GetComponent<Canvas>();
    }


    public void Sonido()
    {
        CanvasMenu.enabled = false;
        CanvasSonido.enabled = true;
    }
    public void Menu()
    {
        CanvasMenu.enabled = true;
        CanvasSonido.enabled = false;
    }


}
