using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogicaInteractuable : MonoBehaviour
{

    private Camera mainCamera;
    public float interactionRange = 2f;
    public LayerMask interactionLayer;

    public GameObject Mano;

    public bool desactivarUI = false;

    private void Start()
    {
        mainCamera = Camera.main;
    }

    void Update()
    {

        if(desactivarUI == false)
        {
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

                if (Physics.Raycast(ray, out hit, interactionRange, interactionLayer))
                {
                    if (hit.collider.gameObject == gameObject)
                    {
                        Mano.SetActive(true);
                    }
            

                }
                else
                {
                    Mano.SetActive(false);
                }
        }
    }

    public void DesactivarMano()
    {

        Mano.SetActive(false);

    }


}
