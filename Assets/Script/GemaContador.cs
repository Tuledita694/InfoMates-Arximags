using UnityEngine;

public class Gema : MonoBehaviour
{
    public PuertaController puertaController;  // Asigna el script PuertaController desde el Inspector

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Verificar si el objeto que colisiona tiene el tag 'Player'
        if (other.CompareTag("Player"))
        {
            // Notificar a la puerta que se recogió una gema
            puertaController.SumarGema();

            // Destruir la gema actual
            Destroy(gameObject);
        }
    }
}
