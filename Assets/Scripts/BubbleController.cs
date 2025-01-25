using System;
using UnityEngine;

public class BubbleController : MonoBehaviour
{
    public float moveSpeed = 2f;
    public float scaleMultiplier = 1.2f;
    private Gamemanager gameManager;

    private void Start()
    {
       gameManager = FindObjectOfType<Gamemanager>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.position += new Vector3(0, 1f) * Time.deltaTime * moveSpeed;
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.position += new Vector3(0, -1f) * Time.deltaTime * moveSpeed;
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.position += new Vector3(-1f, 0f) * Time.deltaTime* moveSpeed;
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += new Vector3(1f, 0f) * Time.deltaTime* moveSpeed;
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
