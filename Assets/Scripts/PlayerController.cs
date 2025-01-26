using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public GameObject ghost, bubble;
    public Animator animator;
    public float deathAnimationDuration = 3.5f;
    
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
        GameManager.Instance._audioSource.PlayOneShot(deathSound, 1f);
        GameManager.Instance.SetGameState(GameState.PlayerDeath);

        // TODO bubble explosion
        bubble.SetActive(false);
        yield return new WaitForSeconds(deathAnimationDuration);
        string currentSceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(currentSceneName);
        GameManager.Instance.SetGameState(GameState.Playing);
        // Destroy(bubble);
        yield return null;
    }
}
