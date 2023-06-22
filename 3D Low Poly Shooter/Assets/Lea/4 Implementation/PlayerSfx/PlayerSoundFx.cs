using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSoundFx : MonoBehaviour
{
    public AudioSource audiomanager;
    public AudioClip sfxsteps, sfxjump, sfxshot;

    //implementar al obtener movimiento del jugador
    public void Steps()
    {
        audiomanager.clip = sfxsteps;
        if(audiomanager.loop != true)
        {
            audiomanager.Play();
        }
        audiomanager.loop = true;
    }

    public void EndSteps()
    {
        if(audiomanager.clip == sfxsteps)
        {
            audiomanager.Stop();
            audiomanager.loop = false;
        }
    }

    //implementar al saltar
    public void Jump()
    {
        audiomanager.clip = sfxjump;
        audiomanager.loop = false;
        audiomanager.Play();
    }

    //implementar al disparar
    public void Shot()
    {
        audiomanager.clip = sfxshot;
        audiomanager.loop = false;
        audiomanager.Play();
    }
}
