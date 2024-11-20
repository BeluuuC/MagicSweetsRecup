using UnityEngine;
using UnityEngine.SceneManagement;

public class BotonCreditos : MonoBehaviour
{
    // Método para cargar la escena 'Credits'
    public void IrACreditos()
    {
        SceneManager.LoadScene("Credits");  // Asegúrate que el nombre de la escena sea exactamente 'Credits'
    }
}
