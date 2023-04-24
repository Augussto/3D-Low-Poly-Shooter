using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public Text bulletsText;
    public Text reloadingText;

    public void UpdateBullets(int bulletsLeft, int magazineSize)
    {
        bulletsText.text = bulletsLeft + " / " + magazineSize;
    }
    public void ReloadText(bool showText)
    {
        reloadingText.gameObject.SetActive(showText);
    }
}
