using UnityEngine;

public class ChestInteraction : MonoBehaviour
{
    public GameObject mathMenu; // Referencia al menú de matemáticas
    private bool isPlayerNear = false;

    void Update()
    {
        // Verificar si el jugador presiona "E" cuando está cerca del cofre
        if (isPlayerNear && Input.GetKeyDown(KeyCode.E))
        {
            OpenMathMenu();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Detectar si el jugador entra en el área del cofre
        if (other.CompareTag("Player"))
        {
            isPlayerNear = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        // Detectar si el jugador sale del área del cofre
        if (other.CompareTag("Player"))
        {
            isPlayerNear = false;
        }
    }

    void OpenMathMenu()
    {
        // Activar el menú de matemáticas
        mathMenu.SetActive(true);
        Time.timeScale = 0; // Pausar el juego
    }

    public void CloseMathMenu()
    {
        // Cerrar el menú de matemáticas
        mathMenu.SetActive(false);
        Time.timeScale = 1; // Reanudar el juego
    }
}
