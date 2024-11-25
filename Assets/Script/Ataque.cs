using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ataque : MonoBehaviour
{
    public BoxCollider2D ColisionAtaque; // Referencia al collider de ataque
    private Animator animator; // Controlador de animaciones
    public float timer = 1.2f; // Duración del ataque
    private float currentTimer;
    private bool isAttacking = false; // Indica si el ataque está activo

    void Start()
    {
        currentTimer = timer; // Inicializa el temporizador
        animator = GetComponent<Animator>();

        // Asegúrate de asignar manualmente el collider correcto desde el editor
        if (ColisionAtaque == null)
        {
            Debug.LogError("ColisionAtaque no está asignado. Asigna el collider en el inspector.");
        }
        ColisionAtaque.enabled = false; // Desactiva el collider al inicio
    }

    void Update()
    {
        if (!isAttacking && Input.GetKeyDown(KeyCode.Space))
        {
            StartAttack();
        }

        if (isAttacking)
        {
            currentTimer -= Time.deltaTime;

            if (currentTimer <= 0)
            {
                EndAttack();
            }
        }
    }

    private void StartAttack()
    {
        isAttacking = true;
        currentTimer = timer; // Resetea el temporizador
        animator.SetTrigger("Attack"); // Inicia la animación de ataque
        ColisionAtaque.enabled = true; // Activa el collider
    }

    private void EndAttack()
    {
        isAttacking = false;
        ColisionAtaque.enabled = false; // Desactiva el collider
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("enemy")) // Asegúrate de que el tag del murciélago sea "enemy"
        {
            Destroy(other.gameObject); // Destruye al enemigo
        }
    }
}
