using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunInfo : MonoBehaviour
{
    public float weaponSelected;
    public float amountOfCoins;

    public bool passMiniGame01;
    // Start is called before the first frame update
    void Start()
    {
        weaponSelected = 1f;
        amountOfCoins = 0f;
        passMiniGame01 = false;
    }

}
