using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ContadorEnemigos : MonoBehaviour
{
    private static float cantidadEnemies = 0;
    public Text enemies;

    void Start()
    {
        
    }


    void Update()
    {
        enemies.text = "ENEMIGOS: " + cantidadEnemies;
    }

    public void DeleteEnemy()
    {
        cantidadEnemies -= 1;
    }
    public void AddEnemy()
    {
        cantidadEnemies += 1;
    }
    public void SetEnemies(float x)
    {
        cantidadEnemies = x;
    }
    public float GetCantEnemies()
    {
        return cantidadEnemies;
    }
}
