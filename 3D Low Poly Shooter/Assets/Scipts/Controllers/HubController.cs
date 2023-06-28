using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HubController : MonoBehaviour
{
    [SerializeField] private UIController uic;
    [SerializeField] private RunInfo runInfo;
    // Start is called before the first frame update
    void Start()
    {
        runInfo = FindObjectOfType<RunInfo>();
        uic.UpdateCoinText(runInfo.amountOfCoins);
    }
}
