using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public Text bulletsText;
    public Text reloadingText;

    [SerializeField] private GameObject loadingPanel;
    [SerializeField] private Text coinText;
    [SerializeField] private Image lifebar;

    private void Start()
    {
        StartCoroutine(LoadingPanel());
    }

    public IEnumerator LoadingPanel()
    {
        loadingPanel.SetActive(true);
        yield return new WaitForSeconds(1f);
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
    public void UpdateCoinText(float coins)
    {
        coinText.text = "COINS: " + coins;
    }
    public void UpdateLifebar(float w)
    {
        lifebar.rectTransform.sizeDelta = new Vector2(w, 100);
    }
}
