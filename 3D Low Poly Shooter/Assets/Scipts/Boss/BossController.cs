using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour
{
    [SerializeField] float maxLife, currentLife;
    [SerializeField] WeaponSystem ws;
    [SerializeField] BossUI bossUI;
    // Start is called before the first frame update
    void Start()
    {
        currentLife = maxLife;
        ws = FindObjectOfType<WeaponSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        if(currentLife <= 0)
        {
            EndGame();
        }
    }
    public void RecieveDamage()
    {
            currentLife -= ws.damage;
            bossUI.TakeDamage(currentLife);
    }

    public void EndGame()
    {
        Debug.Log("End Game");
    }
}
