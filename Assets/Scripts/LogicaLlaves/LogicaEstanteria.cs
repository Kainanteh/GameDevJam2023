using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogicaEstanteria : MonoBehaviour
{
    public KeyCode interactionKey = KeyCode.E;
    public float interactionRange = 2f;
    public LayerMask interactionLayer;

    private Camera mainCamera;


    public GameObject LLave_objeto;
    public bool llave_cogida;

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

                    if(llave_cogida == false)
                    {
                        llave_cogida = true;
                        LLave_objeto.SetActive(false);
                        logicaCerradurasScript.Llave_Sala_3 = true;
                    }
                 

            
                }
            }
        }
    }
}
