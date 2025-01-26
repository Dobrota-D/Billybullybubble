using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blow : MonoBehaviour
{
    [SerializeField] AudioSource m_audioSource;
    public Vector2 blowForce;

    private void Update()
    {
        if (!m_audioSource.isPlaying)
        {
            StartCoroutine(Audio());
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bubble"))
        {
            Rigidbody2D rb = collision.GetComponent<Rigidbody2D>();

            if (rb != null)
            {
                rb.AddForce(blowForce, ForceMode2D.Impulse);
            }
        }
    }

    private IEnumerator Audio()
    {
        m_audioSource.Play();
        yield return new WaitForSeconds(0.5f);
    }
}
