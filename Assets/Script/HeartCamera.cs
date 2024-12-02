using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartCamera : MonoBehaviour
{
    public Camera mainCamera; // Cámara principal
    public List<GameObject> hearts = new List<GameObject>(); // Lista de corazones
    public Vector3 offset = new Vector3(10f, -10f, 0f); // Offset para la posición de los corazones
    public float separation = 2f; // Separación pequeña entre los corazones

    void Update()
    {
        // Posición de la cámara
        Vector3 cameraPos = mainCamera.transform.position;

        // Posicionar los corazones en línea horizontal de derecha a izquierda
        for (int i = 0; i < hearts.Count; i++)
        {
            // Cambiar el cálculo de la posición para invertir el orden de los corazones
            Vector3 heartPosition = cameraPos + offset + new Vector3((hearts.Count - 1 - i) * separation, 0f, 0f);

            // Asignar la posición del corazón
            hearts[i].transform.position = heartPosition;
        }
    }
}
