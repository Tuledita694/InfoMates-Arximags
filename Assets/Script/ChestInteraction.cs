using UnityEngine;

public class ChestInteraction : MonoBehaviour
{
    public GameObject mathMenu; // Referencia al men� de matem�ticas
    private bool isPlayerNear = false;

    void Update()
    {
        // Verificar si el jugador presiona "E" cuando est� cerca del cofre
        if (isPlayerNear && Input.GetKeyDown(KeyCode.E))
        {
            OpenMathMenu();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Detectar si el jugador entra en el �rea del cofre
        if (other.CompareTag("Player"))
        {
            isPlayerNear = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        // Detectar si el jugador sale del �rea del cofre
        if (other.CompareTag("Player"))
        {
            isPlayerNear = false;
        }
    }

    void OpenMathMenu()
    {
        // Activar el men� de matem�ticas
        mathMenu.SetActive(true);
        Time.timeScale = 0; // Pausar el juego
    }

    public void CloseMathMenu()
    {
        // Cerrar el men� de matem�ticas
        mathMenu.SetActive(false);
        Time.timeScale = 1; // Reanudar el juego
    }
}
