using UnityEngine;
using TMPro;

public class InteractuarCofre : MonoBehaviour
{
    public GameObject VentanaMates; // Referencia al Canvas
    public TMP_Text mathText;      // Referencia al texto de la operaci�n
    public TMP_InputField answerField; // Campo de entrada
    public TMP_Text feedbackText;  // Texto de feedback (opcional)

    private bool isPlayerNear = false;
    private int correctAnswer;

    void Update()
    {
        // Detectar si el jugador presiona "E" estando cerca del cofre
        if (isPlayerNear && Input.GetKeyDown(KeyCode.E))
        {
            OpenMathMenu();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Detectar si el jugador entra en el �rea del cofre (especificar tag si necesario)
        if (other.CompareTag("Player"))  // Cambiar "Player" si tu tag del jugador es diferente
        {
            isPlayerNear = true;  // El jugador entra en el �rea del trigger
            Debug.Log("Jugador cerca del cofre.");
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        // Detectar si el jugador sale del �rea del cofre
        if (other.CompareTag("Player"))  // Cambiar "Player" si tu tag del jugador es diferente
        {
            isPlayerNear = false;  // El jugador ha salido del �rea del trigger
            Debug.Log("Jugador ha salido del �rea del cofre.");
        }
    }

    void OpenMathMenu()
    {
        VentanaMates.SetActive(true); // Activar el Canvas
        Time.timeScale = 0;          // Pausar el juego
        GenerateMathOperation();     // Generar una operaci�n matem�tica
    }

    public void CloseMathMenu()
    {
        VentanaMates.SetActive(false); // Cerrar el Canvas
        Time.timeScale = 1;            // Reanudar el juego
        feedbackText.text = "";        // Limpiar el feedback
    }

    void GenerateMathOperation()
    {
        int a = Random.Range(1, 10); // Generar n�mero aleatorio
        int b = Random.Range(1, 10);
        correctAnswer = a + b;       // Calcular la respuesta correcta
        mathText.text = $"�Cu�nto es {a} + {b}?"; // Mostrar la operaci�n
    }

    public void CheckAnswer()
    {
        int playerAnswer;
        if (int.TryParse(answerField.text, out playerAnswer))
        {
            if (playerAnswer == correctAnswer)
            {
                feedbackText.text = "�Correcto!";
                CloseMathMenu();
            }
            else
            {
                feedbackText.text = "Respuesta incorrecta. Intenta de nuevo.";
            }
        }
        else
        {
            feedbackText.text = "Por favor, introduce un n�mero v�lido.";
        }
    }
}
