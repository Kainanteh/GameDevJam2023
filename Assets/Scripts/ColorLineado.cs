using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorLineado : MonoBehaviour
{
    public Color colorInicial;
    public Color colorFinal;
    public float duracion = 2f;

    private Renderer renderer;
    private Material material;
    private float tiempoInicio;
    private bool enTransicion;

    private void Awake()
    {
        renderer = GetComponent<Renderer>();
        material = renderer.material;
    }

    private void Start()
    {
        // IniciarTransicion();
        CambiarColorMaterial(colorInicial);
    }

    private void Update()
    {
        if (enTransicion)
        {
            float tiempoActual = Time.time - tiempoInicio;
            float t = Mathf.Clamp01(tiempoActual / duracion);
            Color colorActual = Color.Lerp(colorInicial, colorFinal, t);
            CambiarColorMaterial(colorActual);

            if (t >= 1f)
            {
                enTransicion = false;
            }
        }
    }

    public void IniciarTransicion()
    {
        tiempoInicio = Time.time;
        enTransicion = true;
    }

    public void CambiarColorMaterial(Color color)
    {
        material.SetColor("_BaseColor", color);
    }

    //335CDB
}
