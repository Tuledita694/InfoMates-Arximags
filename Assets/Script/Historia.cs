using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Historia : MonoBehaviour
{

    string frase = "En el reino sombrío de Umbrael, donde el sol se ha ocultado durante siglos, las criaturas de la noche dominan el mundo. Snich, un cazador errante con un oscuro pasado, es el último sobreviviente de una orden extinta conocida como los Veladores del Alba. Armado con una cruzbow encantada y un puñado de reliquias mágicas, Snich viaja entre aldeas arruinadas y fortalezas malditas, buscando acabar con la maldición eterna que envuelve al mundo.\r\n\r\nTodo cambia cuando encuentra un mapa tallado en hueso que señala la ubicación de la Gema Carmesí, una reliquia ancestral capaz de devolver el amanecer al reino. Pero no está solo en esta misión: hordas de vampiros, licántropos y brujas le siguen los pasos, protegiendo el oscuro secreto que mantiene al sol aprisionado.\r\n\r\nLa única forma de sobrevivir es aprender de sus enemigos: cada criatura derrotada deja fragmentos de su esencia, que Snich puede usar para volverse más fuerte. Pero debe elegir con cuidado, porque cada poder que absorbe lo acerca más al abismo que juró destruir.\r\n\r\n¿Podrá Snich recuperar la luz antes de perderse en la oscuridad?";
    public Text texto;

    void Start()
    {
        StartCoroutine(Reloj());
    }

    IEnumerator Reloj()
    {
        foreach (char caracter in frase)
        {
            texto.text = texto.text + caracter;
            yield return new WaitForSeconds(0.0f);
        }
    }
}