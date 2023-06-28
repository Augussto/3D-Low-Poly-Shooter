using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinCounter : MonoBehaviour
{
    [SerializeField] private float currentCoins;
    [SerializeField] private UIController uic;
    private RunInfo runInfo;

    // Start is called before the first frame update
    void Start()
    {
        currentCoins = 0;
        uic = FindObjectOfType<UIController>();
        runInfo = FindObjectOfType<RunInfo>();
    }

    public void AddCoin()
    {
        currentCoins++;
        runInfo.amountOfCoins = currentCoins;
        uic.UpdateCoinText(currentCoins);
    }
    public void ResetCoins()
    {
        currentCoins = 0;
    }
}
