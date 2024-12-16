using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;  // Para cargar la escena

public class EnemyBehavior : MonoBehaviour
{
    public GameObject player;
    public float speed = 4f;
    private int hitCount = 0;
    private const int maxHits = 3;
    public float separationRadius = 1f; // Radio de separación entre enemigos
    public float separationForce = 1f; // Fuerza de separación

    private List<GameObject> hearts = new List<GameObject>();    // Corazones rojos
    private List<GameObject> noHearts = new List<GameObject>(); // Corazones grises

    private AudioSource audioSource; // Componente AudioSource para reproducir el sonido
    public AudioClip golpeSound; // Aud

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

        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            // Si no hay AudioSource, agregar uno dinámicamente
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        // Cargar el sonido golpe.mp3
        golpeSound = Resources.Load<AudioClip>("golpe"); // Asegúrate de que el archivo está en Resources
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
            if (hitCount < maxHits)
            {
                hitCount++;

                // Reproducir el sonido de golpe
                audioSource.PlayOneShot(golpeSound);

                // Destruir los objetos según el golpe (heart, heart2, heart3)
                if (hitCount == 1)
                {
                    GameObject heart = GameObject.Find("heart");
                    if (heart != null)
                    {
                        Renderer heartRenderer = heart.GetComponent<Renderer>();
                        if (heartRenderer != null)
                        {
                            heartRenderer.enabled = false; // Desactiva el renderizado, haciendo el objeto invisible
                        }
                    }
                }
                else if (hitCount == 2)
                {
                    GameObject heart2 = GameObject.Find("heart2");
                    if (heart2 != null)
                    {
                        Renderer heart2Renderer = heart2.GetComponent<Renderer>();
                        if (heart2Renderer != null)
                        {
                            heart2Renderer.enabled = false; // Desactiva el renderizado, haciendo el objeto invisible
                        }
                    }
                }
                else if (hitCount == 3)
                {
                    GameObject heart3 = GameObject.Find("heart3");
                    if (heart3 != null)
                    {
                        Renderer heart3Renderer = heart3.GetComponent<Renderer>();
                        if (heart3Renderer != null)
                        {
                            heart3Renderer.enabled = false; // Desactiva el renderizado, haciendo el objeto invisible
                        }
                    }
                }

                // Cuando el jugador ha sido golpeado tres veces, se destruye
                if (hitCount >= maxHits)
                {
                    // Destruir al jugador
                    Destroy(other.gameObject);
                    Debug.Log("El jugador ha sido destruido.");

                    // Llamar a la función para cargar la pantalla de GameOver después de 3 segundos
                    StartCoroutine(CargarPantallaGameOver());
                }
            }

            if (other.CompareTag("ColisionAtaque"))
            {
                Destroy(gameObject);
                Debug.Log("El enemigo ha sido destruido.");
            }
        }
    }

    private IEnumerator CargarPantallaGameOver()
    {
        // Esperar 3 segundos antes de cargar la escena de GameOver
        yield return new WaitForSeconds(3f);

        // Cargar la escena de GameOver
        SceneManager.LoadScene("GameOver");
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
