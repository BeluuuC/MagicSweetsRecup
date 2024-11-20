using UnityEngine;

public class IngridMovement : MonoBehaviour
{
    public float velocidad = 5f; // Velocidad de movimiento
    private Rigidbody2D rb;
    private Animator animator;

    private bool puedeMoverse = true; // Controla si Ingrid puede moverse

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();   // Obtenemos el Rigidbody2D
        animator = GetComponent<Animator>(); // Obtenemos el Animator
    }

    void Update()
    {
        if (puedeMoverse) // Solo permite moverse si puedeMoverse es true
        {
            HandleMovement();      // Manejo del movimiento
            UpdateAnimation();     // Actualización de animaciones
        }
        else
        {
            rb.velocity = Vector2.zero; // Detén el movimiento si Ingrid no puede moverse
        }
    }

    private void HandleMovement()
    {
        // Movimiento horizontal
        float moveInput = Input.GetAxis("Horizontal"); // Entrada horizontal (A/D o flechas)
        rb.velocity = new Vector2(moveInput * velocidad, rb.velocity.y); // Movimiento horizontal

        // Cambio de dirección del personaje
        if (moveInput > 0) transform.localScale = new Vector3(1, 1, 1); // Mirar hacia la derecha
        else if (moveInput < 0) transform.localScale = new Vector3(-1, 1, 1); // Mirar hacia la izquierda
    }

    // Actualización de animaciones basadas en el movimiento
    private void UpdateAnimation()
    {
        // Animación de movimiento
        float moveX = Mathf.Abs(Input.GetAxis("Horizontal"));
        animator.SetFloat("movement", moveX); // Variable de animación 'movement'
    }

    // Manejo de colisiones con la barrera
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Barrera")) // Si colisiona con un objeto con el tag 'Barrera'
        {
            puedeMoverse = false; // Ingrid no podrá moverse
        }
    }
}

