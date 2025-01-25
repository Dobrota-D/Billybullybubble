using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindBlower : MonoBehaviour
{
    public float[] data;
    private string device;
    public AudioClip audioClip;
    public AudioSource audioSource;

    void Start()
    {
        data = new float[128]; 
        device = Microphone.devices[0];
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = Microphone.Start(device, true, 10, 44100); 
        audioSource.loop = true;
        while (!(Microphone.GetPosition(device) > 0)) { }
        audioSource.Play();
    }

    void Update()
    {
        audioSource.GetOutputData(data, 0);
    }
}
