using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    public GameObject player; // Asigna al jugador manualmente o se buscará por nombre
    public float speed = 2f; // Velocidad del enemigo
    private int hitCount = 0; // Número de veces que ha tocado al jugador
    private const int maxHits = 3; // Máximo de golpes para destruir al jugador

    void Start()
    {
        // Asegúrate de que la escala inicial del objeto sea (1, 1, 1)
        if (transform.localScale != new Vector3(1f, 1f, 1f))
        {
            transform.localScale = new Vector3(1f, 1f, 1f); // Restablece la escala a la inicial si es necesario
        }

        // Buscar al jugador automáticamente por nombre si no se asigna
        if (player == null)
        {
            player = GameObject.Find("idle1pjprincipal_0");
            if (player == null)
            {
                Debug.LogError("No se encontró al jugador con el nombre 'idle1pjprincipal_0'");
                return;
            }
        }
    }

    void Update()
    {
        // Seguir al jugador
        if (player != null)
        {
            Vector3 direction = (player.transform.position - transform.position).normalized;
            transform.position += direction * speed * Time.deltaTime;

            // Volteamos el sprite dependiendo de la dirección
            if (direction.x < 0) // Si el jugador está a la izquierda
            {
                transform.localScale = new Vector3(-1f, 1f, 1f); // Volteamos el sprite (cambiamos el eje X)
            }
            else if (direction.x > 0) // Si el jugador está a la derecha
            {
                transform.localScale = new Vector3(1f, 1f, 1f); // Restauramos la escala original
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Detectar si colisiona con el jugador
        if (other.gameObject.name == "idle1pjprincipal_0")
        {
            hitCount++;
            Debug.Log("Enemigo ha golpeado al jugador. Golpes: " + hitCount);

            if (hitCount >= maxHits)
            {
                // Destruir al jugador
                Destroy(other.gameObject);
                Debug.Log("El jugador ha sido destruido.");
            }
        }

        // Detectar si colisiona con el collider de ataque del mago
        if (other.CompareTag("ColisionAtaque"))
        {
            Destroy(gameObject); // Destruye el murciélago al ser golpeado por el ataque
            Debug.Log("El murciélago ha sido destruido por el ataque.");
        }
    }
}
