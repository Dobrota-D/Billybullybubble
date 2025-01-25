using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;

public class BougeScript : MonoBehaviour
{
    public float moveSpeed = 2f;
    public float incrementationDeLaDimensionDeLaBulle = 1.2f;
    
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
            GrossirBillyLaBulle(other.gameObject);
        }
    }

    private void GrossirBillyLaBulle(GameObject other)
    {
        transform.localScale *= incrementationDeLaDimensionDeLaBulle;
        Destroy(other);
    }
}
