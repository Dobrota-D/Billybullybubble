using System;
using UnityEngine;

public class BubbleController : MonoBehaviour
{
    public float scaleMultiplier = 1.2f;
    private Gamemanager gameManager;

    private void Start()
    {
       gameManager = FindObjectOfType<Gamemanager>();
    }

    private void OnCollisionEnter(Collision other)
    {
        Debug.Log("collision");
        if (other.collider.CompareTag("EnemyBubble"))
        {
            IncreaseScale(other.gameObject);
        }
    }

    private void ExplodeBubble()
    {
        // Destroy(gameObject);
        gameManager.GameOver();
    }

    private void IncreaseScale(GameObject other)
    {
        transform.localScale *= scaleMultiplier;
        // transform.localScale *= 6f;
        Destroy(other);
        if (transform.localScale.x >= 5f)
        {
            ExplodeBubble();
        }
    }
}
