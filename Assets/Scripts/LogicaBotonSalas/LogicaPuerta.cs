using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogicaPuerta : MonoBehaviour
{
    public KeyCode interactionKey = KeyCode.E;
    public float interactionRange = 2f;
    public LayerMask interactionLayer;

    private Camera mainCamera;

    public Animator animator;
    public string booleanParameterName = "AbrirPuerta";

    public bool PuertaActivada = false;

    public Color colorInicial;
    public Color colorFinal;

    public Renderer renderer;
    private  Material material;

    public LogicaInteractuable logicaInteractuableScript;

    public DisparadorSonidos disparadorSonidosScript;


    private void Awake()
    {
        material = renderer.material;
    }

    private void Start()
    {
        mainCamera = Camera.main;
    }

    private void Update()
    {
        if (Input.GetKeyDown(interactionKey) && PuertaActivada == true)
        {
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, interactionRange, interactionLayer))
            {
                if (hit.collider.gameObject == gameObject)
                {
                    animator.SetBool(booleanParameterName, true);
                    CambiarColorMaterial(colorFinal);
                    InteracciactuablePuerta(true);
                    disparadorSonidosScript.DispararSonido(4);
                }
            }
        }
    }

    public void CambiarColorMaterial(Color color)
    {
        material.SetColor("_BaseColor", color);
    }

    public void InteracciactuablePuerta(bool inter)
    {
        logicaInteractuableScript.desactivarUI = inter;
    }
}
