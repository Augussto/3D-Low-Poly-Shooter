using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySFX : MonoBehaviour
{
    private AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayDeadSound()
    {
        audioSource.Play();
    }
}
