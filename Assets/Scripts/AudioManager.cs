using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioClip audioClip;

    public void PlayAudio()
    {
        AudioSource audio = GetComponent<AudioSource>();
        audio.clip = audioClip;
        audio.Play();
    }
}
