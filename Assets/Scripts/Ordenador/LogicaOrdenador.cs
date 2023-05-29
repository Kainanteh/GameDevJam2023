using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LogicaOrdenador : MonoBehaviour
{

    public enum Direccion{ Arriba, Abajo, Derecha, Izquierda }
    private Direccion direccionAleatoria;
    public int DireccionIndex = 0;

    public List<GameObject> DireccionObject;

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

    public int FallosMision = 0;

    public LogicaPuerta logicaPuertaScript;

    public List<GameObject> FGameObject;

    public bool MisionCheckSala0 = false;

    public LogicaBoton LogicaBotonScript;

    public LogicaInteractuable LogicaInteractuableScript;

    public DisparadorSonidos disparadorSonidosScript;

    private void Start()
    {
        mainCamera = Camera.main;
    }

    private void Update()
    {

        if(MisionCheckSala0 == false)
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
                            GenerarDireccionAleatoria();
                            DireccionObjectFalse();
                            DireccionObject[DireccionIndex].SetActive(true);
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

                if (Input.GetKeyDown(KeyCode.UpArrow))
                {
                    DireccionObjectFalse();
                    ComprobarDireccion(Direccion.Arriba);
                    DireccionObject[DireccionIndex].SetActive(true);
                }
                else if (Input.GetKeyDown(KeyCode.DownArrow))
                {
                    DireccionObjectFalse();
                    ComprobarDireccion(Direccion.Abajo);
                    DireccionObject[DireccionIndex].SetActive(true);
                }
                else if (Input.GetKeyDown(KeyCode.RightArrow))
                {
                    DireccionObjectFalse();
                    ComprobarDireccion(Direccion.Derecha);
                    DireccionObject[DireccionIndex].SetActive(true);
                }
                else if (Input.GetKeyDown(KeyCode.LeftArrow))
                {
                    DireccionObjectFalse();
                    ComprobarDireccion(Direccion.Izquierda);
                    DireccionObject[DireccionIndex].SetActive(true);
                }

                if (coroutineEjecutandose == false)
                {
                    // StartCoroutine(ActivarDesactivarGameObject(DireccionObject[DireccionIndex]));
                    StartCoroutine(ActivarDesactivarGameObject(Texto));
                }

            }

        }
        else
        {
           
        }

   
        
    }

    private void GenerarDireccionAleatoria()
    {
        
        int indice = Random.Range(0, 4);
        direccionAleatoria = (Direccion)indice;
        Debug.Log("Dirección aleatoria generada: " + direccionAleatoria);
        DireccionIndex =  indice;
        
    }

    private void ComprobarDireccion(Direccion direccionJugador)
    {
        if (direccionJugador == direccionAleatoria)
        {
            // Debug.Log("¡Correcto! Dirección elegida correctamente.");
            disparadorSonidosScript.DispararSonido(3);
            GenerarDireccionAleatoria();
            FallosMision = 0;
            FObjectFalse();
        }
        else
        {
            // Debug.Log("Incorrecto. Intenta de nuevo.");
            disparadorSonidosScript.DispararSonido(0);
            GenerarDireccionAleatoria();
            FallosMision++;
            FGameObject[FallosMision-1].SetActive(true);
        }

        if(FallosMision == 3)
        {
            disparadorSonidosScript.DispararSonido(2);
            logicaPuertaScript.PuertaActivada = true;
            logicaPuertaScript.InteracciactuablePuerta(false);
            MisionCheckSala0 = true;
            Texto.GetComponent<TextMeshProUGUI>().text = "¡Door Open!";
            LogicaBotonScript.BotonAbierto();
            LogicaBotonScript.botonabierto = true;
          

             DireccionObjectFalse();
                                  mainCamera.enabled = true; 
                        ordenadorCamera.enabled = false; 
                        FirstPersonMovementScript.estatico=false;
                        FirstPersonLookScript.estatico=false;
                        JugadorEnOrdenador = false;
                        LogicaInteractuableScript.desactivarUI = true;
        }

    }

    private void DireccionObjectFalse()
    {

        foreach(GameObject objectdir in DireccionObject)
        {

            objectdir.SetActive(false);

        }

    }

        private void FObjectFalse()
    {

        foreach(GameObject objectf in FGameObject)
        {

            objectf.SetActive(false);

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
