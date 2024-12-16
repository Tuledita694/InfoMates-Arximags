using UnityEngine;
using UnityEngine.SceneManagement;  // Necesario para cambiar de escena

public class ScriptGanar : MonoBehaviour
{
    // Este método se llama cuando algo entra en el trigger
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Verificar si el objeto que colisiona tiene el tag 'Player'
        if (other.CompareTag("Player"))
        {
            // Cargar la escena de victoria
            SceneManager.LoadScene("PantallaVictoria");

        }
    }
}
