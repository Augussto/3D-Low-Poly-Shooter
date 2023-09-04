using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSFX : MonoBehaviour
{
    [SerializeField] AudioSource audiomanager;
    [SerializeField] AudioClip sfxshot;

    //implementar al disparar
    public void Shot()
    {
        audiomanager.clip = sfxshot;
        audiomanager.loop = false;
        audiomanager.Play();
    }
}
