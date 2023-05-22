using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonController : MonoBehaviour
{
    [SerializeField] private float maxDungeonSize;
    [SerializeField] private float currentDungeonSize;

    // Start is called before the first frame update
    void Start()
    {
        maxDungeonSize = 30;
        currentDungeonSize = 1;
    }

    public void RestDungeonSize()
    {
        currentDungeonSize = 1;
    }
    public float GetDungeonMaxSize()
    {
        return maxDungeonSize;
    }
    public float GetDungeonCurrentSize()
    {
        return currentDungeonSize;
    }

    public void CountCurrentDungeon()
    {
        currentDungeonSize++;
    }
}
