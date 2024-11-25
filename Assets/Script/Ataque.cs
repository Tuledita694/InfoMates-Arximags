using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ataque : MonoBehaviour
{
    public BoxCollider2D ColisionAtaque; // Referencia al collider de ataque
    private Animator animator; // Controlador de animaciones
    public float timer = 1.2f; // Duraci�n del ataque
    private float currentTimer;
    private bool isAttacking = false; // Indica si el ataque est� activo

    void Start()
    {
        currentTimer = timer; // Inicializa el temporizador
        animator = GetComponent<Animator>();

        // Aseg�rate de asignar manualmente el collider correcto desde el editor
        if (ColisionAtaque == null)
        {
            Debug.LogError("ColisionAtaque no est� asignado. Asigna el collider en el inspector.");
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
        animator.SetTrigger("Attack"); // Inicia la animaci�n de ataque
        ColisionAtaque.enabled = true; // Activa el collider
    }

    private void EndAttack()
    {
        isAttacking = false;
        ColisionAtaque.enabled = false; // Desactiva el collider
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("enemy")) // Aseg�rate de que el tag del murci�lago sea "enemy"
        {
            Destroy(other.gameObject); // Destruye al enemigo
        }
    }
}
