using UnityEngine;
using UnityEngine.SceneManagement;

public class CambiarEscena : MonoBehaviour
{
    // Función para cambiar a la escena 'EscenaCampo'
    public void CambiarAEscenacampo()
    {
        SceneManager.LoadScene("Escenacampo");
    }
}
