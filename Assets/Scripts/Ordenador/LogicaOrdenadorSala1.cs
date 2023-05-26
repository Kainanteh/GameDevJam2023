using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LogicaOrdenadorSala1 : MonoBehaviour
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

    public GameObject Texto;
    public GameObject Texto_abajo;


    public bool MisionCheck = false;

    public LogicaBoton LogicaBotonScript;

    public string inputRecogido;
    public int numeroAleatorio;


    private void Start()
    {
        mainCamera = Camera.main;
    }

    private void Update()
    {

        if(MisionCheck == false)
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

                        }
                        else
                        {
                            ordenadorCamera.enabled = false; 
                            mainCamera.enabled = true; 

                            FirstPersonMovementScript.estatico=false;
                            FirstPersonLookScript.estatico=false;
                            JugadorEnOrdenador = false;
                        }
                    }
                }
            }

            if(JugadorEnOrdenador == true)
            {
    
                if(Input.anyKeyDown && ( 
                    Input.GetKeyDown(KeyCode.Alpha0) || 
                    Input.GetKeyDown(KeyCode.Alpha1) ||
                    Input.GetKeyDown(KeyCode.Alpha2) || 
                    Input.GetKeyDown(KeyCode.Alpha3) || 
                    Input.GetKeyDown(KeyCode.Alpha4) || 
                    Input.GetKeyDown(KeyCode.Alpha5) || 
                    Input.GetKeyDown(KeyCode.Alpha6) || 
                    Input.GetKeyDown(KeyCode.Alpha7) || 
                    Input.GetKeyDown(KeyCode.Alpha8)
                    ))
                {
                    
                    inputRecogido = Input.inputString;
                    Texto.GetComponent<TextMeshProUGUI>().text = inputRecogido;
                    if(inputRecogido == "7")
                    {
                        MisionCheck = true;
                        Texto_abajo.GetComponent<TextMeshProUGUI>().text = "¡Check!";
                        LogicaBotonScript.BotonAbierto();
                        LogicaBotonScript.botonabierto = true;
                    }
                    else
                    {
                        Texto_abajo.GetComponent<TextMeshProUGUI>().text = "Error, try again";
                        TextoAbajoBorrar(Texto_abajo,"|");
                        TextoAbajoBorrar(Texto,"?");
                        inputRecogido = "0";
                    }

                }

                if (coroutineEjecutandose == false)
                {
                    StartCoroutine(ActivarDesactivarGameObject(Texto));
                }

            }

        }
        else
        {
       
                        mainCamera.enabled = true; 
                        ordenadorCamera.enabled = false; 
                        FirstPersonMovementScript.estatico=false;
                        FirstPersonLookScript.estatico=false;
                        JugadorEnOrdenador = false;
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
    private System.Collections.IEnumerator TextoAbajoBorrar(GameObject objeto, string texto)
    {


        yield return new WaitForSeconds(tiempocoroutine);
        Debug.Log("test");
        objeto.GetComponent<TextMeshProUGUI>().text = texto;
        
    }

 
}
