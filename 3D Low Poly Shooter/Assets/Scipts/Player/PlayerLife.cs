using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLife : MonoBehaviour
{
    public int maxLife, currentLife;

    // Start is called before the first frame update
    void Start()
    {
        maxLife = 10;
        currentLife = maxLife;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
