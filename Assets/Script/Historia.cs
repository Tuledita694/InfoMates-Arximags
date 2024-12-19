using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Historia : MonoBehaviour
{

    string frase = "En el regne ombrívol d’Umbrael, on el sol s’ha amagat durant segles, les criatures de la nit dominen el món. Snich, un caçador errant amb un passat fosc, és l’últim supervivent d’un ordre extint conegut com els Vetlladors de l’Alba. Armat amb una ballesta encantada i un grapat de relíquies màgiques, Snich viatja entre pobles en ruïnes i fortaleses maleïdes, buscant acabar amb la maledicció eterna que envolta el món.  \r\n\r\nTot canvia quan troba un mapa gravat en os que assenyala la ubicació de la Gema Carmesina, una relíquia ancestral capaç de retornar l’alba al regne. Però no està sol en aquesta missió: hordes de vampirs, licantrops i bruixes segueixen els seus passos, protegint el secret fosc que manté el sol empresonat.  \r\n\r\nL’única manera de sobreviure és aprendre dels seus enemics: cada criatura derrotada deixa fragments de la seva essència, que Snich pot utilitzar per fer-se més fort. Però ha de triar amb cura, perquè cada poder que absorbeix l’apropa més a l’abisme que va jurar destruir.  \r\n\r\nPodrà Snich recuperar la llum abans de perdre’s en la foscor?  ";
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