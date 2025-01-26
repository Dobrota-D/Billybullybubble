using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public GameObject ghost, bubble;
    public Animator animator;
    
    [Header("Sound")]
    public AudioClip deathSound;
    
    public void PlayerDeath()
    {
        Debug.Log("PlayerController.PlayerDeath");
        StartCoroutine(PlayerDeathCoroutine());
    }

    private IEnumerator PlayerDeathCoroutine()
    {
        animator.SetTrigger("death");
        GameManager.Instance._audioSource.PlayOneShot(deathSound, 0.5f);
        yield return new WaitForSeconds(4f);
        string currentSceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(currentSceneName);
        // Destroy(bubble);
        yield return null;
    }
}
