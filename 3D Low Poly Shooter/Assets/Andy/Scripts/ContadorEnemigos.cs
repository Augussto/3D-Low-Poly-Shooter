using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ContadorEnemigos : MonoBehaviour
{
    public int cantidadEnemies = 0;
    public Text enemies;

    void Start()
    {
        
    }


    void Update()
    {
        enemies.text = "cantidad de enemigos:" + cantidadEnemies;
    }
}
