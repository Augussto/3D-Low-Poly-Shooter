using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour
{
    [SerializeField] float maxLife, currentLife;
    [SerializeField] WeaponSystem ws;
    [SerializeField] BossUI bossUI;
    [SerializeField] private bool secondPhase;
    [SerializeField] private BossAttacks bossAttacks;
    // Start is called before the first frame update
    void Start()
    {
        currentLife = maxLife;
        ws = FindObjectOfType<WeaponSystem>();
        bossAttacks = GetComponent<BossAttacks>();
    }

    // Update is called once per frame
    void Update()
    {
        if(currentLife <= 0)
        {
            EndGame();
        }else if(!secondPhase && currentLife <= 500)
        {
            secondPhase= true;
            bossAttacks.cooldownAbilities = 1f;
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
