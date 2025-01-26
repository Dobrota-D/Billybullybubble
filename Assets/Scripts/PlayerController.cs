using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public class PlayerController : MonoBehaviour
{
    public GameObject ghost, bubble;
    public Animator animator;
    public float deathAnimationDuration = 3.5f;
    
    [Header("Sound")]
    public AudioClip deathSound;
    public AudioClip[] bubbleExplodeSounds;
    
    public void PlayerDeath()
    {
        Debug.Log("PlayerController.PlayerDeath");
        StartCoroutine(PlayerDeathCoroutine());
    }

    private IEnumerator PlayerDeathCoroutine()
    {
        animator.SetTrigger("death");
        GameManager.Instance._audioSource.PlayOneShot(PlayRandomSound(bubbleExplodeSounds), 1f);
        GameManager.Instance._audioSource.PlayOneShot(deathSound, .8f);
        GameManager.Instance.SetGameState(GameState.PlayerDeath);

        // TODO bubble explosion
        bubble.SetActive(false);
        yield return new WaitForSeconds(deathAnimationDuration);
        string currentSceneName = SceneManager.GetActiveScene().name;
        GameManager.Instance.SetGameState(GameState.Playing);
        SceneManager.LoadScene(currentSceneName);
        yield return null;
    }

    private AudioClip PlayRandomSound(AudioClip[] audioClips)
    {
        var randIndex = Random.Range(0, audioClips.Length);
        return audioClips[randIndex];
    }
}
