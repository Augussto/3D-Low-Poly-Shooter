using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSFX : MonoBehaviour
{
    [SerializeField] AudioSource audiomanager;
    [SerializeField] AudioClip sfxshot;
    [SerializeField] ParticleSystem shootParticles;
    [SerializeField] Animator gunAnimator;

    //implementar al disparar
    public void Shot()
    {
        audiomanager.clip = sfxshot;
        audiomanager.loop = false;
        audiomanager.Play();
        gunAnimator.SetBool("isShooting", true);
        shootParticles.Play();
    }
    public void StopShooting()
    {
        gunAnimator.SetBool("isShooting", false);
    }
}
