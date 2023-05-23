using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineadosLerp : MonoBehaviour
{
    public float duracionPausa = 0.5f;
    public int ritmo = 1;

    private Transform[] objetosTransicion;
    private int index;

    public bool ultimaTransicionCompletada;

    private void Start()
    {
        objetosTransicion = GetComponentsInChildren<Transform>();
        
    }

    private System.Collections.IEnumerator ActivarTransicion()
    {
        
        index = 1;

        while (index < objetosTransicion.Length)
        {
            objetosTransicion[index].GetComponent<ColorLineado>().IniciarTransicion();
            index += ritmo;
            yield return new WaitForSeconds(duracionPausa); 
        }

        yield return new WaitForSeconds(duracionPausa*7); 
        ultimaTransicionCompletada = true;
    }

    public void ActivarColorLerp()
    {
        StartCoroutine(ActivarTransicion());
    }
}