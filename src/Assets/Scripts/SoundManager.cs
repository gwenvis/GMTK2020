using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : SingletonBehaviour<SoundManager>
{

    [SerializeField] private AudioSource src;
    [SerializeField] private AudioClip[] clips;

    internal override void Awake()
    {
        base.Awake();
        DontDestroyOnLoad(this.gameObject);
    }

    public void PlaySound(string soundName)
    {
        for (int i = 0; i < clips.Length; i++)
        {
            if (clips[i].name == soundName)
            {
                src.PlayOneShot(clips[i]);
            }
        }
    }
}
