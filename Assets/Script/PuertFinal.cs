using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // Necesario para cambiar de escena

public class GoToVictoryScreen : MonoBehaviour
{
    // Nombre de la escena de victoria
    public string victorySceneName = "PantallaVictoria";

    // Detecta si el personaje entra en el activador
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // Verifica que el personaje tiene el tag "Player"
        {
            // Cargar la escena de victoria
            SceneManager.LoadScene(victorySceneName);
        }
    }
}
