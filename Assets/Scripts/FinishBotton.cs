using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FinishButton : MonoBehaviour
{
    [SerializeField] private Button finishButton;

    private void Start()
    {
        if (finishButton != null)
        {
            finishButton.onClick.AddListener(GoToMenu);
        }
        else
        {
            Debug.LogError("No se asignó el botón en el inspector.");
        }
    }

    public void GoToMenu() // Es importante que sea pública
    {
        SceneManager.LoadScene("SampleScene");
    }
}
