using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour
{
    public AudioClip background;
    public AudioSource musicSource;

    void Start()
    {
        musicSource.clip = background;
        musicSource.Play();
    }
}