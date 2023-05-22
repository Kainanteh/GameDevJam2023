using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogicaBotonFinal : MonoBehaviour
{

    public int indiceBoton;

    public LogicaSalaFinal LogicaSalaFinalScript;

    public KeyCode interactionKey = KeyCode.E;
    public float interactionRange = 2f;
    public LayerMask interactionLayer;

    private Camera mainCamera;


  

    private void Start()
    {
        mainCamera = Camera.main;
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
                    if(indiceBoton == 1)
                    {
                        LogicaSalaFinalScript.Activador1 = true;
                        LogicaSalaFinalScript.AbrirPuertaFinal();
                    }
                    else if(indiceBoton == 2)
                    {
                        LogicaSalaFinalScript.Activador2 = true;
                        LogicaSalaFinalScript.AbrirPuertaFinal();
                    }
                    else if(indiceBoton == 3)
                    {
                        LogicaSalaFinalScript.Activador3 = true;
                        LogicaSalaFinalScript.AbrirPuertaFinal();
                    }

                }
            }
        }
    }

}
