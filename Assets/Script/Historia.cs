using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Historia : MonoBehaviour
{

    string frase = "En el reino sombr�o de Umbrael, donde el sol se ha ocultado durante siglos, las criaturas de la noche dominan el mundo. Snich, un cazador errante con un oscuro pasado, es el �ltimo sobreviviente de una orden extinta conocida como los Veladores del Alba. Armado con una cruzbow encantada y un pu�ado de reliquias m�gicas, Snich viaja entre aldeas arruinadas y fortalezas malditas, buscando acabar con la maldici�n eterna que envuelve al mundo.\r\n\r\nTodo cambia cuando encuentra un mapa tallado en hueso que se�ala la ubicaci�n de la Gema Carmes�, una reliquia ancestral capaz de devolver el amanecer al reino. Pero no est� solo en esta misi�n: hordas de vampiros, lic�ntropos y brujas le siguen los pasos, protegiendo el oscuro secreto que mantiene al sol aprisionado.\r\n\r\nLa �nica forma de sobrevivir es aprender de sus enemigos: cada criatura derrotada deja fragmentos de su esencia, que Snich puede usar para volverse m�s fuerte. Pero debe elegir con cuidado, porque cada poder que absorbe lo acerca m�s al abismo que jur� destruir.\r\n\r\n�Podr� Snich recuperar la luz antes de perderse en la oscuridad?";
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