using UnityEngine;

public class Ascensor : MonoBehaviour
{
    public float velocidad = 2f;        // Velocidad del ascensor
    public float alturaMaxima = 5f;    // Altura máxima
    public float alturaMinima = 0f;    // Altura mínima

    private bool subiendo = true;      // Controla si sube o baja

    private void Update()
    {
        // Movimiento del ascensor
        if (subiendo)
        {
            transform.Translate(Vector2.up * velocidad * Time.deltaTime);

            // Cuando llega a la altura máxima, comienza a bajar
            if (transform.position.y >= alturaMaxima)
                subiendo = false;
        }
        else
        {
            transform.Translate(Vector2.down * velocidad * Time.deltaTime);

            // Cuando llega a la altura mínima, comienza a subir
            if (transform.position.y <= alturaMinima)
                subiendo = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Si el jugador entra al ascensor, se vuelve hijo del ascensor
        if (collision.CompareTag("Player"))
        {
            collision.transform.SetParent(transform); // El jugador sigue al ascensor
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        // Si el jugador sale del ascensor, deja de ser hijo del ascensor
        if (collision.CompareTag("Player"))
        {
            collision.transform.SetParent(null); // El jugador ya no sigue al ascensor
        }
    }
}
