using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogicaCajonEscritorio : MonoBehaviour
{

    public KeyCode interactionKey = KeyCode.E;
    public float interactionRange = 2f;
    public LayerMask interactionLayer;

    private Camera mainCamera;

    public Animator cajonAnimator;

    public GameObject LLave_objeto;
    public bool cajon_abierto;

    public LogicaCerraduras logicaCerradurasScript;

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

                    if(cajon_abierto == false)
                    {
                        cajonAnimator.SetBool("cajon_abierto", true);
                        cajon_abierto = true;
                    }
                    else
                    {
                        LLave_objeto.SetActive(false);
                        logicaCerradurasScript.Llave_Sala_0 = true;
                    }

            
                }
            }
        }
    }

}
