using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireTrapEvent : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip clip;

    public void Playsound()
    {
        audioSource.PlayOneShot(clip);
    }

}