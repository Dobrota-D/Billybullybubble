using System;
using UnityEngine;

public class BubbleController : MonoBehaviour
{
    public float scaleMultiplier = 1.2f;
    public bool debugMode;
    
    private GameManager gameManager;

    private void Start()
    {
       gameManager = FindObjectOfType<GameManager>();
    }

    private void Update()
    {
        if (debugMode)
        {
            if (Input.GetKey(KeyCode.W))
            {
                transform.position += new Vector3(0f, 1f, 0f) * (5f * Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.S))
            {
                transform.position += new Vector3(0f, -1f, 0f) * (5f * Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.A))
            {
                transform.position += new Vector3(-1f, 0f , 0f) * (5f * Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.D))
            {
                transform.position += new Vector3(1f , 0f, 0f) * (5f * Time.deltaTime);
            }
        }
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
