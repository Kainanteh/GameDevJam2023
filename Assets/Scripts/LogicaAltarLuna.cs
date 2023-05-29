using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogicaAltarLuna : MonoBehaviour
{
    public KeyCode interactionKey = KeyCode.E;
    public float interactionRange = 2f;
    public LayerMask interactionLayer;

    private Camera mainCamera;


    public GameObject luna;
    public bool luna_cogida;

    public LogicaSolLuna logicaSolLunaScript ;

        public DisparadorSonidos disparadorSonidosScript;

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

                    if(logicaSolLunaScript.Sol == false)
                    {

                        if(luna_cogida == false)
                        {
                            luna_cogida = true;
                            luna.SetActive(false);
                            logicaSolLunaScript.Luna = true;
                            disparadorSonidosScript.DispararSonido(6);
                        }
                        else
                        {
                            luna_cogida = false;
                            luna.SetActive(true);
                            logicaSolLunaScript.Luna = false;
                            disparadorSonidosScript.DispararSonido(7);
                        }

                    }

                }
            }
        }
    }
}
