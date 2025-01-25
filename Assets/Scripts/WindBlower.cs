using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindBlower : MonoBehaviour
{
    public float[] data;
    private string device;
    public AudioClip audioClip;
    public AudioSource audioSource;
    public BoxCollider2D WindBox;
    public float WindForce;

    // A multiplier to scale the WindForce value
    public float forceMultiplier = 10f;

    void Start()
    {
        data = new float[128];
        device = Microphone.devices[0];
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = Microphone.Start(device, true, 10, 44100);
        audioSource.loop = true;

        // Wait for the microphone to start recording
        while (!(Microphone.GetPosition(device) > 0)) { }
        audioSource.Play();
    }

    void Update()
    {
        // Get the audio data
        audioSource.GetOutputData(data, 0);

        // Calculate the RMS value of the audio data
        float rms = 0f;
        for (int i = 0; i < data.Length; i++)
        {
            rms += data[i] * data[i];
        }
        rms = Mathf.Sqrt(rms / data.Length);

        // Set the WindForce based on the RMS value
        WindForce = rms * forceMultiplier;

        // Debug log to monitor WindForce
        Debug.Log("WindForce: " + WindForce);

        // Optionally, apply WindForce to the WindBox or other game logic
        ApplyWindForce();
    }

    void ApplyWindForce()
    {
        // Example: Apply the WindForce to the BoxCollider2D or related behavior
        if (WindBox != null)
        {
            Rigidbody2D rb = WindBox.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.AddForce(Vector2.right * WindForce);
            }
        }
    }

}
