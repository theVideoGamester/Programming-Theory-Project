using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SoundAgent
{
    public AudioClip damageSound;
    public AudioClip missSound;
    public AudioClip deathSound;
    public AudioSource audioSource;

    public void Damaged()
    {
        if (damageSound != null) 
        {
            audioSource.PlayOneShot(damageSound);
        }
    }
    public void Missed(AudioClip miss)
    {
        if (miss != null)
        {
            audioSource.PlayOneShot(miss);
        }
    }
    public void Died(AudioClip death)
    {
        if (death != null)
        {
            audioSource.PlayOneShot(death);
        }
    }
}
