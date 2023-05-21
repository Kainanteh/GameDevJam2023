using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogicaBoton : MonoBehaviour
{
    public KeyCode interactionKey = KeyCode.E;
    public float interactionRange = 2f;
    public LayerMask interactionLayer;

    private Camera mainCamera;

    public Animator animator;
    public string booleanParameterName = "IsTrue";

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
                    // Debug.Log("El jugador está apuntando hacia el objeto y ha presionado la tecla 'E'");
                    // Realiza aquí las acciones que deseas cuando se cumplan las condiciones
                    animator.SetBool(booleanParameterName, true);
                }
            }
        }
    }
}
