using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    public GameObject player;
    public float speed = 2f;
    private int hitCount = 0;
    private const int maxHits = 3;
    public float separationRadius = 1f; // Radio de separación entre enemigos
    public float separationForce = 1f; // Fuerza de separación

    void Start()
    {
        if (transform.localScale != new Vector3(1f, 1f, 1f))
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
        }

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
        if (player != null)
        {
            // Dirección hacia el jugador
            Vector3 direction = (player.transform.position - transform.position).normalized;

            // Ajustar posición con separación
            Vector3 separation = GetSeparationVector();
            Vector3 finalDirection = direction + separation;

            transform.position += finalDirection.normalized * speed * Time.deltaTime;

            // Voltear sprite
            if (direction.x < 0)
            {
                transform.localScale = new Vector3(-1f, 1f, 1f);
            }
            else if (direction.x > 0)
            {
                transform.localScale = new Vector3(1f, 1f, 1f);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "idle1pjprincipal_0")
        {
            hitCount++;
            Debug.Log("Enemigo ha golpeado al jugador. Golpes: " + hitCount);

            if (hitCount >= maxHits)
            {
                Destroy(other.gameObject);
                Debug.Log("El jugador ha sido destruido.");
            }
        }

        if (other.CompareTag("ColisionAtaque"))
        {
            Destroy(gameObject);
            Debug.Log("El murciélago ha sido destruido por el ataque.");
        }
    }

    private Vector3 GetSeparationVector()
    {
        Vector3 separation = Vector3.zero;
        Collider2D[] nearbyEnemies = Physics2D.OverlapCircleAll(transform.position, separationRadius);

        foreach (Collider2D collider in nearbyEnemies)
        {
            if (collider.gameObject != gameObject && collider.CompareTag("Enemy"))
            {
                Vector3 difference = transform.position - collider.transform.position;
                separation += difference.normalized / difference.magnitude; // Incrementa más cuanto más cerca
            }
        }

        return separation * separationForce;
    }

    private void OnDrawGizmosSelected()
    {
        // Visualización del radio de separación
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, separationRadius);
    }
}
