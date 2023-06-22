using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLife : MonoBehaviour
{
    public float maxLife, currentLife;
    private GameManager gm;
    private UIController uic;

    // Start is called before the first frame update
    void Start()
    {
        gm = FindObjectOfType<GameManager>();
        uic = FindObjectOfType<UIController>();
        maxLife = 10;
        currentLife = maxLife;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RecieveDamage(float damage)
    {
        currentLife -= damage;
        uic.UpdateLifebar(currentLife*10);
        if(currentLife <= 0)
        {
            gm.ReturnToHub();
        }
    }
}
