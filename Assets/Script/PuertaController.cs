using UnityEngine;

public class PuertaController : MonoBehaviour
{
    public GameObject puertaCambio;   // Asigna el objeto puertaCambio desde el Inspector
    public GameObject puertaFinal;    // Asigna el objeto puertaFinal desde el Inspector
    private int contadorGemas = 0;    // Contador de gemas recogidas

    // Método para contar gemas recogidas
    public void SumarGema()
    {
        contadorGemas++;

        // Si se han recogido 4 gemas, activar puertaCambio y desactivar puertaFinal
        if (contadorGemas >= 4)
        {
            puertaCambio.SetActive(true);   // Activar puertaCambio
            puertaFinal.SetActive(false);   // Desactivar puertaFinal
        }
    }
}
