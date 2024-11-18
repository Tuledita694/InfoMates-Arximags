using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverAwsd : MonoBehaviour
{
    public float moveSpeed = 5f; // Velocidad del movimiento
    private Animator animator;  // Controlador de animaciones
    private SpriteRenderer spriteRenderer; // Para controlar la dirección del sprite

    void Start()
    {
        // Obtiene los componentes necesarios
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        // Obtén la entrada del jugador
        float horizontal = Input.GetAxisRaw("Horizontal"); // A (-1) y D (+1)
        float vertical = Input.GetAxisRaw("Vertical");     // W (+1) y S (-1)

        // Calcula el movimiento
        Vector2 movement = new Vector2(horizontal, vertical).normalized;

        // Mueve al personaje
        transform.Translate(movement * moveSpeed * Time.deltaTime);

        // Controla las animaciones y el sprite
        if (movement != Vector2.zero) // Si hay movimiento


        {

            animator.SetBool("IsRunning", true);

            if (horizontal > 0) // Movimiento hacia la derecha
            {
                animator.Play("Caminar"); // Activa la animación hacia la derecha
                spriteRenderer.flipX = false;       // Asegúrate de que no esté volteado
               
            }
            else if (horizontal < 0) // Movimiento hacia la izquierda
            {
                animator.Play("Caminar"); // Reutiliza la misma animación
                spriteRenderer.flipX = true;        // Voltea el sprite
               
            }
        }
        else // Si no hay movimiento
        {
            animator.SetBool("IsRunning", false); // Vuelve a Idle
        }
    }
}
