using UnityEngine;

public class BubbleController : MonoBehaviour
{
    public float scaleMultiplier = 1.2f;

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
