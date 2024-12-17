using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateEnemy : MonoBehaviour
{
    // Asigna el enemigo en el inspector de Unity
    public GameObject enemyToActivate;

    // Referencias al SpriteRenderer y al script EnemyBehavior
    private SpriteRenderer enemySpriteRenderer;
    private EnemyBehavior enemyBehavior;

    private void Start()
    {
        if (enemyToActivate != null)
        {
            enemySpriteRenderer = enemyToActivate.GetComponent<SpriteRenderer>();
            enemyBehavior = enemyToActivate.GetComponent<EnemyBehavior>();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Habilitar el SpriteRenderer
            if (enemySpriteRenderer != null)
            {
                enemySpriteRenderer.enabled = true;
            }

            // Cambiar la velocidad a 3 y actualizar speedInit
            if (enemyBehavior != null)
            {
                enemyBehavior.speed = 3f;
                enemyBehavior.speedInit = 3f;
                enemyBehavior.playerIsComputing = false;
            }
        }
    }
}
