using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossUI : MonoBehaviour
{
    [SerializeField] Image lifeBar;

    public void TakeDamage(float currentLife)
    {
        lifeBar.fillAmount = currentLife / 1000;
    }
}
