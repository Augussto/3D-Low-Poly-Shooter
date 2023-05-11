using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesController : MonoBehaviour
{
    public BasicEnemyAI[] cantidadEnemigos;
    public ContadorEnemigos cantidad;
    public UIController UIcontroller;
    void Start()
    {
        UIcontroller = FindObjectOfType<UIController>();
        cantidad = UIcontroller.GetComponent<ContadorEnemigos>();
    }

    void Update()
    {
        cantidadEnemigos = FindObjectsOfType<BasicEnemyAI>();
        cantidad.cantidadEnemies = cantidadEnemigos.Length;
    }
}
