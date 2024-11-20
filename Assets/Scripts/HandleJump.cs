using UnityEngine;

public class IngridJump : MonoBehaviour
{
    public float jumpForce = 15f;          // Fuerza del salto
    public float fallMultiplier = 2.5f;   // Multiplicador para caída más rápida
    public float lowJumpMultiplier = 2f;  // Multiplicador para salto corto

    private Rigidbody2D rb;
    private bool isGrounded = false;      // Verifica si Ingrid está tocando el suelo

    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // Obtenemos el Rigidbody2D del objeto
        if (rb == null) Debug.LogError("Falta el componente Rigidbody2D.");
    }

    void Update()
    {
        HandleJump();        // Maneja el salto
        ApplyJumpPhysics();  // Aplica mejoras en la física del salto
    }

    private void HandleJump()
    {
        // Salto solo si Ingrid está en el suelo
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce); // Aplica la fuerza de salto
        }
    }

    private void ApplyJumpPhysics()
    {
        // Si Ingrid está cayendo más rápido de lo normal
        if (rb.velocity.y < 0)
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }
        // Si está en un salto corto (cuando se suelta la tecla Space antes de completar el salto)
        else if (rb.velocity.y > 0 && !Input.GetKey(KeyCode.Space))
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
        }
    }

    // Detecta si Ingrid está tocando el suelo
    private void OnCollisionStay2D(Collision2D collision)
    {
        isGrounded = true; // Si hay colisión, Ingrid está en el suelo
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        isGrounded = false; // Si deja de colisionar, Ingrid no está en el suelo
    }
}
