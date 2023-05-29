using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogicaAltarSol : MonoBehaviour
{
    public KeyCode interactionKey = KeyCode.E;
    public float interactionRange = 2f;
    public LayerMask interactionLayer;

    private Camera mainCamera;


    public GameObject sol;
    public bool sol_cogido;

    public LogicaSolLuna logicaSolLunaScript ;

    public DisparadorSonidos disparadorSonidosScript;


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

                if(logicaSolLunaScript.Luna == false)
                {

                    if (hit.collider.gameObject == gameObject)
                    {

                        if(sol_cogido == false)
                        {
                            sol_cogido = true;
                            sol.SetActive(false);
                            logicaSolLunaScript.Sol = true;
                               disparadorSonidosScript.DispararSonido(6);
                        }
                        else
                        {
                            sol_cogido = false;
                            sol.SetActive(true);
                            logicaSolLunaScript.Sol = false;
                              disparadorSonidosScript.DispararSonido(7);
                        }
                    

                
                    }

                }

            }
        }
    }
}
