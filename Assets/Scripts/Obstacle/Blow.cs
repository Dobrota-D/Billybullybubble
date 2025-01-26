using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blow : MonoBehaviour
{
    [SerializeField] AudioSource m_audioSource;
    public float blowForce = 10f;
    public float radius = 5f;
    public float upForce = 1f;


    private void Update()
    {
        if (!m_audioSource.isPlaying)
        {
            StartCoroutine(Audio());
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bubble"))
        {
            Vector3 explosionPos = transform.position;
            Collider[] colliders = Physics.OverlapSphere(explosionPos, radius);

            foreach (Collider hit in colliders)
            {
                Rigidbody rb = hit.GetComponent<Rigidbody>();

                if (rb != null)
                {
                    rb.AddExplosionForce(blowForce, explosionPos, radius, upForce, ForceMode.Impulse);
                }
            }
        }
    }

    private IEnumerator Audio()
    {
        m_audioSource.Play();
        yield return new WaitForSeconds(0.5f);
    }
}
