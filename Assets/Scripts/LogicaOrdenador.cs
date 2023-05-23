using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogicaOrdenador : MonoBehaviour
{

   public KeyCode interactionKey = KeyCode.E;
    public float interactionRange = 2f;
    public LayerMask interactionLayer;

    private Camera mainCamera;

    public Camera ordenadorCamera;

    public FirstPersonMovement FirstPersonMovementScript;
    public FirstPersonLook FirstPersonLookScript;

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
                    if(mainCamera.enabled == true)
                    {
                        mainCamera.enabled = false; 
                        ordenadorCamera.enabled = true; 
                        FirstPersonMovementScript.estatico=true;
                        FirstPersonLookScript.estatico=true;
                    }
                    else
                    {
                        mainCamera.enabled = true; 
                        ordenadorCamera.enabled = false; 
                        FirstPersonMovementScript.estatico=false;
                        FirstPersonLookScript.estatico=false;
                    }
                }
            }
        }
    }

}
