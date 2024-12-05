using UnityEngine;
using TMPro;

public class InteractuarCofre : MonoBehaviour
{
    public GameObject VentanaMates; // Referencia al Canvas
    public TMP_Text mathText;      // Referencia al texto de la operación
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
        // Detectar si el jugador entra en el área del cofre (especificar tag si necesario)
        if (other.CompareTag("Player"))  // Cambiar "Player" si tu tag del jugador es diferente
        {
            isPlayerNear = true;  // El jugador entra en el área del trigger
            Debug.Log("Jugador cerca del cofre.");
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        // Detectar si el jugador sale del área del cofre
        if (other.CompareTag("Player"))  // Cambiar "Player" si tu tag del jugador es diferente
        {
            isPlayerNear = false;  // El jugador ha salido del área del trigger
            Debug.Log("Jugador ha salido del área del cofre.");
        }
    }

    void OpenMathMenu()
    {
        VentanaMates.SetActive(true); // Activar el Canvas
        Time.timeScale = 0;          // Pausar el juego
        GenerateMathOperation();     // Generar una operación matemática
    }

    public void CloseMathMenu()
    {
        VentanaMates.SetActive(false); // Cerrar el Canvas
        Time.timeScale = 1;            // Reanudar el juego
        feedbackText.text = "";        // Limpiar el feedback
    }

    void GenerateMathOperation()
    {
        int a = Random.Range(1, 10); // Generar número aleatorio
        int b = Random.Range(1, 10);
        correctAnswer = a + b;       // Calcular la respuesta correcta
        mathText.text = $"¿Cuánto es {a} + {b}?"; // Mostrar la operación
    }

    public void CheckAnswer()
    {
        int playerAnswer;
        if (int.TryParse(answerField.text, out playerAnswer))
        {
            if (playerAnswer == correctAnswer)
            {
                feedbackText.text = "¡Correcto!";
                CloseMathMenu();
            }
            else
            {
                feedbackText.text = "Respuesta incorrecta. Intenta de nuevo.";
            }
        }
        else
        {
            feedbackText.text = "Por favor, introduce un número válido.";
        }
    }
}
