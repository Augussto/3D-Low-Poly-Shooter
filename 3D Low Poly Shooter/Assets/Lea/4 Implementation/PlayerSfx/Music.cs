using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour
{
    public AudioSource audiomanager;
    public AudioClip music1, music2, music3, music4;

    public void Start()
    {
        cancion1();
    }

    public void cancion1()
    {
        audiomanager.clip = music1;
        audiomanager.Play();
    }
}
