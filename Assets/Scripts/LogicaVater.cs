using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogicaVater : MonoBehaviour
{

    public KeyCode interactionKey = KeyCode.E;
    public float interactionRange = 2f;
    public LayerMask interactionLayer;

    private Camera mainCamera;

    public Animator vaterAnimator;

    public GameObject LLave_objeto;
    public bool vater_abierto;

    public LogicaCerraduras logicaCerradurasScript;

    public LogicaInteractuable logicaInteractuableScript;

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

                    if(vater_abierto == false)
                    {
                        vaterAnimator.SetBool("tapa_abierta", true);
                        vater_abierto = true;
                        logicaInteractuableScript.desactivarUI = true;
                    }
                    else
                    {
                        LLave_objeto.SetActive(false);
                        logicaCerradurasScript.Llave_Sala_1 = true;
                    }

            
                }
            }
        }
    }
}
