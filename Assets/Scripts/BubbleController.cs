using UnityEngine;

public class BubbleController : MonoBehaviour
{
    public float moveSpeed = 2f;
    public float scaleMultiplier = 1.2f;
    
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

    private void IncreaseScale(GameObject other)
    {
        transform.localScale *= scaleMultiplier;
        Destroy(other);
    }
}
