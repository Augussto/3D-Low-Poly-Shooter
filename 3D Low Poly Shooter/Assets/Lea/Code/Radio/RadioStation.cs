using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class RadioStation : MonoBehaviour
{

    public Sprite stationSprite;

    [HideInInspector]
    public AudioSource audioSource;

    public List<AudioClip> stationClips;
    List<AudioClip> currentStationClips;

    public AudioClip currentClip;
    public int currentClipNumber;

    public bool currentRadio;
    public bool stopRadio;
    [HideInInspector]
    public float waitTime;


    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        shuffleRadio();
    }


    void Update()
    {
        if (currentRadio != true && stopRadio != true) 
        {
            waitTime -= 1 * Time.deltaTime;
            if(waitTime <= 0) 
            {
                audioSource.Stop();
                shuffleRadio(); 
                stopRadio = true;
            }
        }

        if (stopRadio !=  true) 
        {
            if (!audioSource.isPlaying) 
            {
                currentClipNumber += 1;
                if(currentClipNumber >= currentStationClips.Count) 
                { 
                    currentClipNumber = 0;
                }

                currentClip = currentStationClips[currentClipNumber];
                audioSource.clip = currentClip; 
                audioSource.Play();
            }
        }
    }

    public void shuffleRadio() 
    {
        currentStationClips = stationClips;
        List<int> numbersTaken = new List<int>();

        for (int i = 0; i < stationClips.Count; i++) 
        {
            bool next = false;
            while (next != true) 
            {
                int newNumber = Random.Range(0, stationClips.Count);
                if(numbersTaken.Contains(newNumber) != true) 
                {
                    currentStationClips[i] = stationClips[newNumber];
                    next = true;
                }
            }
        }
    }

}
