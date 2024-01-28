using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class RandomAudio : MonoBehaviour
{
    public AudioClip[] audioClips;
    //public AudioSource audioSource;
    
    public float minTime = 15f;
    public float maxTime = 20f;

    private float timer = 30f;
    
    
    private void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            PlayAudio();
            timer = Random.Range(minTime, maxTime);
        }
        
    }

    private void PlayAudio()
    {
        int index = Random.Range(0, audioClips.Length - 1);
        
        AudioSource audio = GetComponent<AudioSource>();
        audio.clip = audioClips[index];
        audio.Play();
    }
}
