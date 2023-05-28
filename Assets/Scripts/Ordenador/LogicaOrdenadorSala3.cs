using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogicaOrdenadorSala3 : MonoBehaviour
{

   public KeyCode interactionKey = KeyCode.E;
    public float interactionRange = 2f;
    public LayerMask interactionLayer;

    private Camera mainCamera;

    public Camera ordenadorCamera;

    public FirstPersonMovement FirstPersonMovementScript;
    public FirstPersonLook FirstPersonLookScript;

    public bool JugadorEnOrdenador = false;

    public bool coroutineEjecutandose = false;
    public float tiempocoroutine = 2f;

    public LogicaInteractuable LogicaInteractuableScript;





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
                            ordenadorCamera.enabled = true; 
                            mainCamera.enabled = false; 
                            
                            FirstPersonMovementScript.estatico=true;
                            FirstPersonLookScript.estatico=true;
                            JugadorEnOrdenador = true;
                            LogicaInteractuableScript.desactivarUI = true;
                            LogicaInteractuableScript.Mano.SetActive(false);
                             

                        }
                        else
                        {
                            ordenadorCamera.enabled = false; 
                            mainCamera.enabled = true; 

                            FirstPersonMovementScript.estatico=false;
                            FirstPersonLookScript.estatico=false;
                            JugadorEnOrdenador = false;
                            LogicaInteractuableScript.desactivarUI = false;
                        }
                    }
                }
            }

            if(JugadorEnOrdenador == true)
            {
    
           
                if (coroutineEjecutandose == false)
                {
                    // StartCoroutine(ActivarDesactivarGameObject(Texto));
                }

            }

    

   
        
    }



 




    private System.Collections.IEnumerator ActivarDesactivarGameObject(GameObject objeto)
    {
        coroutineEjecutandose = true;

            objeto.SetActive(false);
            yield return new WaitForSeconds(tiempocoroutine);
            objeto.SetActive(true);
            yield return new WaitForSeconds(tiempocoroutine);

        coroutineEjecutandose = false;
        
        
    }


}
