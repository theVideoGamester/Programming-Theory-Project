using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SoundAgent
{
    public AudioClip damageSound;
    public AudioClip missSound;
    private AudioSource _audioSource;
    public AudioSource audioSource { get { return _audioSource; } }

    public SoundAgent(AudioSource audio, AudioClip dam, AudioClip miss)
    {
        _audioSource = audio;
        damageSound = dam;
        missSound = miss;
    }

    public void Damaged()
    {
        if (damageSound != null) 
        {
            _audioSource.PlayOneShot(damageSound);
        }
    }
    public void Missed()
    {
        if (missSound != null)
        {
            _audioSource.PlayOneShot(missSound);
        }
    }
}
