using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;  // Necesario para cambiar de escena

public class ScriptGameOver : MonoBehaviour
{
    // Método para destruir al personaje y cambiar a GameOver después de 3 segundos
    public void DestruirPersonajeYGameOver()
    {
        // Destruir al personaje
        Destroy(gameObject);

        // Iniciar la coroutine para esperar 3 segundos y cargar la escena de GameOver
        StartCoroutine(CargarGameOver());
    }

    // Coroutine para esperar 3 segundos y cambiar de escena
    private IEnumerator CargarGameOver()
    {
        // Esperar 3 segundos
        yield return new WaitForSeconds(3f);

        // Cargar la escena de GameOver
        SceneManager.LoadScene("GameOver");
    }
}
