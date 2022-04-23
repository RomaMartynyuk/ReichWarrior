using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumeValue : MonoBehaviour
{
    private AudioSource musicSrc;
    private float musicVolume = 1f;

    void Start()
    {
        musicSrc = GetComponent<AudioSource>();
    }

    void Update()
    {
        musicSrc.volume = musicVolume;
    }

    public void SetVolume(float vol)
    {
        musicVolume = vol;
    }
}
