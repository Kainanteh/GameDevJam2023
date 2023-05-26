using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LogicaOrdenadorSala2 : MonoBehaviour
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
                             GenerarNumero();

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

    private void GenerarNumero()
    {
        numeroAleatorio = Random.Range(0, 100 + 1);
        Texto_abajo.GetComponent<TextMeshProUGUI>().text = numeroAleatorio.ToString();

    }

}
