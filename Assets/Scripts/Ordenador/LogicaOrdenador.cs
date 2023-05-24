using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogicaOrdenador : MonoBehaviour
{

    public enum Direccion{ Arriba, Abajo, Derecha, Izquierda }
    private Direccion direccionAleatoria;

   public KeyCode interactionKey = KeyCode.E;
    public float interactionRange = 2f;
    public LayerMask interactionLayer;

    private Camera mainCamera;

    public Camera ordenadorCamera;

    public FirstPersonMovement FirstPersonMovementScript;
    public FirstPersonLook FirstPersonLookScript;

    public bool JugadorEnOrdenador = false;

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
                        JugadorEnOrdenador = true;
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
            }
        }

        if(JugadorEnOrdenador == true)
        {

            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                ComprobarDireccion(Direccion.Arriba);
            }
            else if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                ComprobarDireccion(Direccion.Abajo);
            }
            else if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                ComprobarDireccion(Direccion.Derecha);
            }
            else if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                ComprobarDireccion(Direccion.Izquierda);
            }

        }
        
    }


    private void GenerarDireccionAleatoria()
    {
        direccionAleatoria = (Direccion)Random.Range(0, 4);
        Debug.Log("Dirección aleatoria generada: " + direccionAleatoria);
    }

    private void ComprobarDireccion(Direccion direccionJugador)
    {
        if (direccionJugador == direccionAleatoria)
        {
            Debug.Log("¡Correcto! Dirección elegida correctamente.");
            GenerarDireccionAleatoria();
        }
        else
        {
            Debug.Log("Incorrecto. Intenta de nuevo.");
            GenerarDireccionAleatoria();
        }
    }


}
