using UnityEngine;

public class IngridFlight : MonoBehaviour
{
    public float flightSpeed = 3f;        // Velocidad de vuelo
    public float flightGravity = 0.2f;   // Gravedad mínima mientras vuela
    public float normalGravity = 1f;     // Gravedad normal en tierra
    public float liftOffset = 0.5f;      // Distancia para levantar a Ingrid al iniciar vuelo

    private bool isFlying = false;       // Indica si Ingrid está volando
    private Rigidbody2D rb;
    private Animator animator;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // Obtenemos el Rigidbody2D del objeto
        animator = GetComponent<Animator>(); // Obtenemos el Animator del objeto

        if (rb == null) Debug.LogError("Falta el componente Rigidbody2D.");
        if (animator == null) Debug.LogError("Falta el componente Animator.");

        // Configuración inicial: Ingrid está en su estado normal
        rb.gravityScale = normalGravity; // Activar gravedad inicial
        animator.SetBool("IsFlying", false); // Asegura que no está en modo vuelo
    }

    void Update()
    {
        HandleFlight(); // Lógica de vuelo
    }

    private void HandleFlight()
    {
        // Inicia el vuelo al presionar la tecla 'J'
        if (Input.GetKeyDown(KeyCode.J))
        {
            isFlying = true;                   // Activar modo vuelo
            rb.gravityScale = flightGravity;   // Reducir gravedad durante el vuelo
            rb.velocity = Vector2.zero;        // Detener cualquier movimiento previo
            transform.position += new Vector3(0, liftOffset, 0); // Levantar ligeramente a Ingrid
            animator.SetBool("IsFlying", true); // Cambiar a animación de vuelo
        }

        // Si Ingrid está volando, controla su velocidad vertical con 'W' y 'S'
        if (isFlying)
        {
            float verticalInput = 0;

            if (Input.GetKey(KeyCode.W))
                verticalInput = flightSpeed; // Volar hacia arriba
            else if (Input.GetKey(KeyCode.S))
                verticalInput = -flightSpeed; // Volar hacia abajo

            rb.velocity = new Vector2(rb.velocity.x, verticalInput); // Actualizar velocidad
        }

        // Si se suelta la tecla 'J', Ingrid deja de volar
        if (Input.GetKeyUp(KeyCode.J))
        {
            isFlying = false;
            rb.gravityScale = normalGravity;        // Restaurar gravedad normal
            animator.SetBool("IsFlying", false);    // Volver a animación normal
        }
    }
}
