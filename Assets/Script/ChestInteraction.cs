using UnityEngine;
using TMPro;

public class InteractuarCofre : MonoBehaviour
{
    public GameObject VentanaMates; // Referencia al Canvas
    public TMP_Text mathText;       // Referencia al texto de la operaci�n
    public TMP_InputField answerField; // Campo de entrada
    public TMP_Text feedbackText;   // Texto de feedback (opcional)

    public GameObject gema1;        // Referencia al objeto "gema1"
    public GameObject Cofre1;       // Referencia al objeto "Cofre1" (este objeto)

    private bool isPlayerNear = false;
    private int correctAnswer;

    void Update()
    {
        if (isPlayerNear && Input.GetKeyDown(KeyCode.E))
        {
            OpenMathMenu();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNear = true;
            Debug.Log("Jugador cerca del cofre.");
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNear = false;
            Debug.Log("Jugador ha salido del �rea del cofre.");
        }
    }

    void OpenMathMenu()
    {
        VentanaMates.SetActive(true);
        Time.timeScale = 0;
        GenerateMathOperation();
    }

    public void CloseMathMenu()
    {
        VentanaMates.SetActive(false);
        Time.timeScale = 1;
        feedbackText.text = "";
    }

    void GenerateMathOperation()
    {
        // Asegurarnos de que la operaci�n sea v�lida generando nuevos n�meros cada vez
        int a = Random.Range(1, 20);
        int b = Random.Range(1, 20);
        int operation = Random.Range(0, 4); // 0: suma, 1: resta, 2: multiplicaci�n, 3: divisi�n

        switch (operation)
        {
            case 0: // Suma
                correctAnswer = a + b;
                mathText.text = $"�Cu�nto es {a} + {b}?";
                break;
            case 1: // Resta
                // Asegurarnos de que el resultado no sea negativo
                if (a < b) { int temp = a; a = b; b = temp; }
                correctAnswer = a - b;
                mathText.text = $"�Cu�nto es {a} - {b}?";
                break;
            case 2: // Multiplicaci�n
                correctAnswer = a * b;
                mathText.text = $"�Cu�nto es {a} � {b}?";
                break;
            case 3: // Divisi�n
                // Asegurarnos de que la divisi�n sea exacta y evitar divisi�n por 0
                b = Random.Range(1, 10); // Limitar b para divisiones m�s sencillas
                a = b * Random.Range(1, 10); // Generar un m�ltiplo de b
                correctAnswer = a / b;
                mathText.text = $"�Cu�nto es {a} � {b}?";
                break;
        }

        Debug.Log($"La respuesta correcta es: {correctAnswer}");
    }

    public void CheckAnswer()
    {
        if (answerField == null)
        {
            Debug.LogError("answerField no est� asignado en el Inspector.");
            return;
        }
        if (mathText == null)
        {
            Debug.LogError("mathText no est� asignado en el Inspector.");
            return;
        }
        if (feedbackText == null)
        {
            Debug.LogError("feedbackText no est� asignado en el Inspector.");
            return;
        }

        int playerAnswer;
        if (int.TryParse(answerField.text, out playerAnswer))
        {
            if (playerAnswer == correctAnswer)
            {
                feedbackText.text = "�Correcto!";
                CloseMathMenu();
                ShowGema();
            }
            else
            {
                feedbackText.text = "Respuesta incorrecta.";
                GenerateMathOperation();
                answerField.text = "";
            }
        }
        else
        {
            feedbackText.text = "Por favor, introduce un n�mero v�lido.";
            answerField.text = "";
        }
    }

    public void ApretarBoton()
    {
        CheckAnswer();
    }

    void ShowGema()
    {
        if (Cofre1 != null)
        {
            Cofre1.SetActive(false); // Desactiva el objeto "Cofre1"
            Debug.Log("Cofre1 desactivado.");
        }

        if (gema1 != null)
        {
            gema1.SetActive(true);  // Activa el objeto "gema1"
            Debug.Log("Gema1 activada.");
        }
    }
}
