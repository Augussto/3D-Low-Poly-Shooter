using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HurtEffect : MonoBehaviour
{
    // the image you want to fade, assign in inspector
    public Image img;

    public void HurtPlayer()
    {
        // fades the image out when you click
        StartCoroutine(FadeImage(true));
    }

    IEnumerator FadeImage(bool fadeAway)
    {
        img.color = new Color(255, 0, 0, 0.5f);
        // fade from opaque to transparent
        if (fadeAway)
        {
            // loop over 1 second backwards
            for (float i = 1; i >= 0; i -= Time.deltaTime)
            {
                // set color with i as alpha
                img.color = new Color(255, 0, 0, i);
                yield return null;
            }
        }

    }
}
