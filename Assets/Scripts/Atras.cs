using UnityEngine;
using UnityEngine.SceneManagement;

public class BotonAtras : MonoBehaviour
{
    // Método para cargar la escena 'SampleScene'
    public void IrASampleScene()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
