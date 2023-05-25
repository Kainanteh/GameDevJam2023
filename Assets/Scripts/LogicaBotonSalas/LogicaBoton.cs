using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogicaBoton : MonoBehaviour
{
    public KeyCode interactionKey = KeyCode.E;
    public float interactionRange = 2f;
    public LayerMask interactionLayer;

    private Camera mainCamera;

    // public Animator animator;
    public string booleanParameterName = "IsTrue";

    public Animator animatorBotonAbierto;

    public LineadosLerp LineadosLerpScript;

    public Animator animatorBoton;
    public bool botonabierto = false;

    private void Start()
    {
        mainCamera = Camera.main;
    }


    public void BotonAbierto()
    {

        animatorBotonAbierto.SetBool("BotonAbierto", true);

    }



    private void Update()
    {
        if (Input.GetKeyDown(interactionKey) && botonabierto == true)
        {
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, interactionRange, interactionLayer))
            {
                if (hit.collider.gameObject == gameObject)
                {
                    // animator.SetBool(booleanParameterName, true);
                    animatorBoton.SetBool("BotonPulsado", true);
                    if(LineadosLerpScript != null)
                    {
                        LineadosLerpScript.ActivarColorLerp();
                    }
                }
            }
        }
    }
}
