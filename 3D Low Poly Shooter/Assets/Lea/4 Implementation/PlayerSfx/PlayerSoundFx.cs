using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSoundFx : MonoBehaviour
{
    public AudioSource audiomanager;
    public AudioClip sfxsteps, sfxjump;

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
        Debug.Log("SFX: salto");
        Debug.Log(audiomanager.clip);
        EndSteps(); 
        audiomanager.loop = false;
        audiomanager.clip = sfxjump;
        Debug.Log(audiomanager.clip);
        audiomanager.Play();
    }

}
