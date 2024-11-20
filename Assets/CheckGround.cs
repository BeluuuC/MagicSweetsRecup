using UnityEngine;

public class CheckGround : MonoBehaviour
{
    public static bool isGrounded; // Variable estática para verificar si está en el suelo

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Suelo"))
        {
            isGrounded = true;
            Debug.Log("Ingrid está en el suelo"); // Confirmar que se detecta el suelo
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Suelo"))
        {
            isGrounded = false;
            Debug.Log("Ingrid salió del suelo"); // Confirmar que deja de detectar el suelo
        }
    }
}
