using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSoundFx : MonoBehaviour
{
    public AudioSource audiomanager;
    public AudioClip sfxsteps, sfxjump, sfxshot;

    //implementar al obtener movimiento del jugador
    public void steps()
    {
        audiomanager.clip = sfxsteps;
        audiomanager.Play();
    }

    //implementar al saltar
    public void jump()
    {
        audiomanager.clip = sfxjump;
        audiomanager.Play();
    }

    //implementar al disparar
    public void shot()
    {
        audiomanager.clip = sfxshot;
        audiomanager.Play();
    }
}
