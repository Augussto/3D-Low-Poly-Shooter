using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public Text bulletsText;
    public Text reloadingText;

    [SerializeField] private GameObject loadingPanel;

    private void Start()
    {
        StartCoroutine(LoadingPanel());
    }

    IEnumerator LoadingPanel()
    {
        loadingPanel.SetActive(true);
        yield return new WaitForSeconds(5f);
        loadingPanel.SetActive(false);
    }

    public void UpdateBullets(int bulletsLeft, int magazineSize)
    {
        bulletsText.text = bulletsLeft + " / " + magazineSize;
    }
    public void ReloadText(bool showText)
    {
        reloadingText.gameObject.SetActive(showText);
    }
}
