using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager1 : MonoBehaviour
{
    [SerializeField] Slider volumeSlider;

    void Start()
    {
        if (!PlayerPrefs.HasKey("musicVolume"))
        {
            PlayerPrefs.SetFloat("musicVolume", 1);
        }
        else
        {
            cargar();
        }
    }

    public void cambiarVolumen()
    {
        AudioListener.volume = volumeSlider.value;
        guardar();
    }
    private void cargar()
    {
        volumeSlider.value = PlayerPrefs.GetFloat("musicVolume");
    }
    private void guardar()
    {
        PlayerPrefs.SetFloat("musicVolume", volumeSlider.value);
    }
}
