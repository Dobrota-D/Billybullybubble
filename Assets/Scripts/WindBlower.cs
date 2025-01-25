using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindBlower : MonoBehaviour
{
    private float[] data;
    public AudioSource audioSource;
    public float micGate;
    public Rigidbody billyBullRb;
    public float pushForce = 3f;
    
    public const float windMultiplier = 10f;
    private float WindForce;

    private string device;

    int decibel = 128;

    AudioClip microphoneInput;
    public bool flapped;

    void Start()
    {
        data = new float[decibel];

        //init microphone input
        if (Microphone.devices.Length > 0)
        {
            device = Microphone.devices[0];
            microphoneInput = Microphone.Start(device, true, 10, 44100);
        }
    }

    void Update()
    {

        //get mic volume
        int micPosition = Microphone.GetPosition(device) - (decibel + 1); // null means the first microphone
        if (micPosition < 0) return;
        microphoneInput.GetData(data, micPosition);

        // Getting a peak on the last 128 samples
        float wavePeak = 0;
        for (int i = 0; i < decibel; i++)
        {
            wavePeak += data[i] * data[i];
        }
        float level = Mathf.Sqrt(Mathf.Sqrt(wavePeak));

        // Set the WindForce based on the RMS value
        WindForce = wavePeak * windMultiplier;
        Debug.Log("WindForce " + WindForce);

        // Debug log to monitor WindForce
        // Debug.Log("WindForce: " + WindForce);

        // Optionally, apply WindForce to the WindBox or other game logic
        ApplyWindForce();
    }

    void ApplyWindForce()
    {
        if (WindForce >= micGate)
        {
            billyBullRb.AddForce(transform.right * pushForce);
        }
    }

}
