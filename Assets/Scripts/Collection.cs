using UnityEngine;

public class Collection : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
        
            Destroy(gameObject, 0.2f);
        }
    }
}