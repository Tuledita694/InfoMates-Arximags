using UnityEngine;

public class CameraFollow2D : MonoBehaviour
{
    // Objeto que la c�mara debe seguir
    public Transform target;

    // Offset para ajustar la posici�n de la c�mara
    public Vector3 offset;

    // Velocidad del movimiento suave
    public float smoothSpeed = 0.125f;

    void FixedUpdate()
    {
        // Verifica que el objeto a seguir est� asignado
        if (target != null)
        {
            // Calcula la posici�n deseada, manteniendo el offset en X y Z, pero ajustando Y
            Vector3 desiredPosition = target.position + offset;

            // Mantener la c�mara a la misma altura (Y) que el jugador, para evitar que suba o baje
            desiredPosition.y = target.position.y + offset.y;

            // Interpola suavemente hacia la posici�n deseada
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

            // Establece la nueva posici�n de la c�mara
            transform.position = smoothedPosition;
        }
        else
        {
            Debug.LogError("No se asign� un objeto al campo 'Target' en el script CameraFollow2D.");
        }
    }
}
