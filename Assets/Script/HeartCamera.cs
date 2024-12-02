using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartCamera : MonoBehaviour
{
    public Camera mainCamera; // C�mara principal
    public List<GameObject> hearts = new List<GameObject>(); // Lista de corazones
    public Vector3 offset = new Vector3(10f, -10f, 0f); // Offset para la posici�n de los corazones
    public float separation = 2f; // Separaci�n peque�a entre los corazones

    void Update()
    {
        // Posici�n de la c�mara
        Vector3 cameraPos = mainCamera.transform.position;

        // Posicionar los corazones en l�nea horizontal de derecha a izquierda
        for (int i = 0; i < hearts.Count; i++)
        {
            // Cambiar el c�lculo de la posici�n para invertir el orden de los corazones
            Vector3 heartPosition = cameraPos + offset + new Vector3((hearts.Count - 1 - i) * separation, 0f, 0f);

            // Asignar la posici�n del coraz�n
            hearts[i].transform.position = heartPosition;
        }
    }
}
