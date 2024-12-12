using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int lives = 3; // N�mero de vidas del jugador

    // Llamar a esta funci�n para reducir vidas
    public void TakeDamage()
    {
        lives--;

        if (lives <= 0)
        {
            GameOver();
        }
    }

    // Funci�n para cambiar a la pantalla GameOver
    void GameOver()
    {
        SceneManager.LoadScene("GameOver");
    }
}
