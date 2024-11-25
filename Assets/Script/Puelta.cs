using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puelta : MonoBehaviour
{
    // Detecta la colisión con el personaje principal
    void OnTriggerEnter2D(Collider2D other)
    {
        // Verifica si el objeto que toca el cuadrado es el personaje principal
        if (other.gameObject.name == "idle1pjprincipal_0")
        {
            // Mueve al personaje principal 100 unidades hacia arriba (en el eje Y)
            other.transform.position += new Vector3(-1, 65, 0);
        }
    }
}
