using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Historia : MonoBehaviour
{

    string frase = "En el regne ombr�vol d�Umbrael, on el sol s�ha amagat durant segles, les criatures de la nit dominen el m�n. Snich, un ca�ador errant amb un passat fosc, �s l��ltim supervivent d�un ordre extint conegut com els Vetlladors de l�Alba. Armat amb una ballesta encantada i un grapat de rel�quies m�giques, Snich viatja entre pobles en ru�nes i fortaleses male�des, buscant acabar amb la maledicci� eterna que envolta el m�n.  \r\n\r\nTot canvia quan troba un mapa gravat en os que assenyala la ubicaci� de la Gema Carmesina, una rel�quia ancestral capa� de retornar l�alba al regne. Per� no est� sol en aquesta missi�: hordes de vampirs, licantrops i bruixes segueixen els seus passos, protegint el secret fosc que mant� el sol empresonat.  \r\n\r\nL��nica manera de sobreviure �s aprendre dels seus enemics: cada criatura derrotada deixa fragments de la seva ess�ncia, que Snich pot utilitzar per fer-se m�s fort. Per� ha de triar amb cura, perqu� cada poder que absorbeix l�apropa m�s a l�abisme que va jurar destruir.  \r\n\r\nPodr� Snich recuperar la llum abans de perdre�s en la foscor?  ";
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