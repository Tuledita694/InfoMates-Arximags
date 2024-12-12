using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateEnemy : MonoBehaviour
{
    // Asigna el enemigo en el inspector de Unity
    public GameObject enemyToActivate;

    // Detecta si el personaje entra en el activador
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // Asegúrate de que el personaje tiene el tag "Player"
        {
            // Activa el enemigo
            if (enemyToActivate != null)
            {
                enemyToActivate.SetActive(true);
            }
        }
    }
}
