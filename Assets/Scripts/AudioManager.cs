using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioClip audioClip;
    public List<AudioClip> audioClip2 = new List<AudioClip>();
    public void PlayAudio()
    {
        AudioSource audio = GetComponent<AudioSource>();
        audio.clip = audioClip;
        audio.Play();
    }

    public void PlayAudioTorso()
    {
        AudioSource audio = GetComponent<AudioSource>();
        int index = Random.Range(0, audioClip2.Count - 1);
        audio.clip = audioClip2[index];
        audio.Play();
    }
}
