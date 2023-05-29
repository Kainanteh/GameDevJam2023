using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogicaAltarFinal : MonoBehaviour
{

    public LogicaSolLuna logicaSolLunaScript;

    public KeyCode interactionKey = KeyCode.E;
    public float interactionRange = 2f;
    public LayerMask interactionLayer;

    private Camera mainCamera;

    public GameObject SolObject;
    public GameObject LunaObject;

    public FirstPersonLook firstPersonLookScript;
    public FirstPersonMovement firstPersonMovementScript;

    public LogicaInteractuable logicaInteractuableScript;

    public Camera CamaraCinematica;

    public Animator CinematicaAnimator;


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
                if (hit.collider.gameObject == gameObject)
                {

                    if(logicaSolLunaScript.Sol == true)
                    {

                        SolObject.SetActive(true);
                        
                        CinematicaAnimator.enabled = true;

                        mainCamera.enabled = false; 
                        CamaraCinematica.enabled = true; 
                        firstPersonMovementScript.estatico=true;
                        firstPersonLookScript.estatico=true;
                        logicaInteractuableScript.desactivarUI=true;
                        logicaInteractuableScript.DesactivarMano();
                        CinematicaAnimator.SetBool("Sol", true);
                              disparadorSonidosScript.DispararSonido(7);

                    }

                    if(logicaSolLunaScript.Luna == true)
                    {

                        LunaObject.SetActive(true);
                        
                        CinematicaAnimator.enabled = true;

                        mainCamera.enabled = false; 
                        CamaraCinematica.enabled = true; 
                        firstPersonMovementScript.estatico=true;
                        firstPersonLookScript.estatico=true;
                        logicaInteractuableScript.desactivarUI=true;
                        logicaInteractuableScript.DesactivarMano();
                        CinematicaAnimator.SetBool("Luna", true);
                              disparadorSonidosScript.DispararSonido(7);

                    }

                    

                }
            }
        }
    }

}
