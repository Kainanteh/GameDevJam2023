using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogicaBotonSala3 : MonoBehaviour
{
    public KeyCode interactionKey = KeyCode.E;
    public float interactionRange = 2f;
    public LayerMask interactionLayer;

    private Camera mainCamera;


    public Animator animatorBotonAbierto;

    public Animator animatorBoton;

    public LogicaBoton LogicaBotonScript;


    public DisparadorSonidos disparadorSonidosScript;

    private void Start()
    {
        mainCamera = Camera.main;
    }


    public void BotonAbierto()
    {

        animatorBotonAbierto.SetBool("BotonAbierto", true);

    }



    private void Update()
    {
        if (Input.GetKeyDown(interactionKey))
        {
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, interactionRange, interactionLayer))
            {
                if (hit.collider.gameObject == gameObject)
                {
                    // animator.SetBool(booleanParameterName, true);
                    animatorBoton.SetBool("BotonPulsado", true);
                    LogicaBotonScript.BotonAbierto();
                    LogicaBotonScript.botonabierto = true;
                    disparadorSonidosScript.DispararSonido(3);
                        disparadorSonidosScript.DispararSonido(2);
                    
                
                }
            }
        }
    }
}
