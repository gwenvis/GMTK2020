using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundNoise : MonoBehaviour
{
    [SerializeField]
    private AudioSource audioPlayer;
    [SerializeField]
    private AudioClip[] audioSources;

    // Start is called before the first frame update
    void Start()
    {
        CallAudio();
    }

    void CallAudio()
    {
        InvokeRepeating("RandomSounds", 45.0f, 55.0f);
    }

    void RandomSounds()
    {
        audioPlayer.clip = audioSources[Random.Range(0, audioSources.Length)];
        audioPlayer.Play();
        CallAudio();
    }
}
