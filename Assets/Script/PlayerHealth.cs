using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int lives = 3; // Número de vidas del jugador

    // Llamar a esta función para reducir vidas
    public void TakeDamage()
    {
        lives--;

        if (lives <= 0)
        {
            GameOver();
        }
    }

    // Función para cambiar a la pantalla GameOver
    void GameOver()
    {
        SceneManager.LoadScene("GameOver");
    }
}
