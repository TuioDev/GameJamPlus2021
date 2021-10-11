using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinSound : MonoBehaviour
{
    private AudioSource winAudio;

    private void Start()
    {
        winAudio = GetComponent<AudioSource>();
        winAudio.Play();
    }
}
