using UnityEngine;

public class CameraFollow2D : MonoBehaviour
{
    // Objeto que la cámara debe seguir
    public Transform target;

    // Offset para ajustar la posición de la cámara
    public Vector3 offset;

    // Velocidad del movimiento suave
    public float smoothSpeed = 0.125f;

    void FixedUpdate()
    {
        // Verifica que el objeto a seguir está asignado
        if (target != null)
        {
            // Calcula la posición deseada, manteniendo el offset en X y Z, pero ajustando Y
            Vector3 desiredPosition = target.position + offset;

            // Mantener la cámara a la misma altura (Y) que el jugador, para evitar que suba o baje
            desiredPosition.y = target.position.y + offset.y;

            // Interpola suavemente hacia la posición deseada
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

            // Establece la nueva posición de la cámara
            transform.position = smoothedPosition;
        }
        else
        {
            Debug.LogError("No se asignó un objeto al campo 'Target' en el script CameraFollow2D.");
        }
    }
}
