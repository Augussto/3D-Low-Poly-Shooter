using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class UnlockedPlayers : ScriptableObject
{
    public int timesCompleted;
    public string playerInUse;
    public string[] playersUnloked;
}
