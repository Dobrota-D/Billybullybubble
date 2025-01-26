using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject ghost, bubble;
    
    [Header("Sound")]
    public AudioClip deathSound;
    
    public void PlayerDeath()
    {
        Debug.Log("PlayerController.PlayerDeath");
        StartCoroutine(PlayerDeathCoroutine());
    }

    private IEnumerator PlayerDeathCoroutine()
    {
        GameManager.Instance._audioSource.PlayOneShot(deathSound);
        Destroy(bubble);
        yield return null;
    }
}
