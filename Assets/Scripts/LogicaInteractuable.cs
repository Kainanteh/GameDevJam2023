using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogicaInteractuable : MonoBehaviour
{

    private Camera mainCamera;
    public float interactionRange = 2f;
    public LayerMask interactionLayer;

    public GameObject Mano;

    private void Start()
    {
        mainCamera = Camera.main;
    }

    void Update()
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
