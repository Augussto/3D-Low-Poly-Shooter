using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicaMenu : MonoBehaviour
{
    public AudioSource musicPlayer;
    // Start is called before the first frame update
    void Start()
    {
        musicPlayer = GetComponent<AudioSource>();
        musicPlayer.Play();
    }
}
