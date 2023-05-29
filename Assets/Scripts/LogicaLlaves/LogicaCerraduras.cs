using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogicaCerraduras : MonoBehaviour
{

    public bool Llave_Sala_0 = false;
    public bool Llave_Sala_1 = false;
    public bool Llave_Sala_2 = false;
    public bool Llave_Sala_3 = false;

    public bool Llave_Sala_0_Introducida = false;
    public bool Llave_Sala_1_Introducida = false;
    public bool Llave_Sala_2_Introducida = false;
    public bool Llave_Sala_3_Introducida = false;

    public GameObject Llave_Sala_0_Object ;
    public GameObject Llave_Sala_1_Object ;
    public GameObject Llave_Sala_2_Object ;
    public GameObject Llave_Sala_3_Object ;

    public KeyCode interactionKey = KeyCode.E;
    public float interactionRange = 2f;
    public LayerMask interactionLayer;

    private Camera mainCamera;

    public Animator animator;
    public string booleanParameterName = "AbrirPuerta";

    public Animator animatorSala0;
    public Animator animatorSala1;
    public Animator animatorSala2;
    public Animator animatorSala3;

    public bool PuertaLunaAbierta = false;

           public DisparadorSonidos disparadorSonidosScript;


    private void Start()
    {
        mainCamera = Camera.main;
    }


    private void Update()
    {

        if (Input.GetKeyDown(interactionKey) )
        {

            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, interactionRange, interactionLayer))
            {
                if (hit.collider.gameObject == gameObject)
                {
                  

                    if( Llave_Sala_0 == true )
                    {
                        Llave_Sala_0_Object.SetActive(true);
                        animatorSala0.SetBool( "llave_introducida" , true );
                           disparadorSonidosScript.DispararSonido(4);
                    }
                    if( Llave_Sala_1 == true )
                    {
                        Llave_Sala_1_Object.SetActive(true);
                        animatorSala1.SetBool( "llave_introducida" , true );
                           disparadorSonidosScript.DispararSonido(4);
                    }
                    if( Llave_Sala_2 == true )
                    {
                        Llave_Sala_2_Object.SetActive(true);
                        animatorSala2.SetBool( "llave_introducida" , true );
                           disparadorSonidosScript.DispararSonido(4);
                    }
                    if( Llave_Sala_3 == true )
                    {
                        Llave_Sala_3_Object.SetActive(true);
                        animatorSala3.SetBool( "llave_introducida" , true );
                           disparadorSonidosScript.DispararSonido(4);
                    }

                }

            }

        }

        if
        ( 
            Llave_Sala_0_Introducida == true &&
            Llave_Sala_1_Introducida == true &&
            Llave_Sala_2_Introducida == true &&
            Llave_Sala_3_Introducida == true && PuertaLunaAbierta == false
        )
        {
            animator.SetBool(booleanParameterName, true);
            PuertaLunaAbierta = true;
             disparadorSonidosScript.DispararSonido(5);
        }

    }

    public void LLaveIntroducida( int index )
    {

        if( index == 0 )
        {
            Llave_Sala_0_Introducida = true;
        }
        if( index == 1 )
        {
            Llave_Sala_1_Introducida = true;
        }
        if( index == 2 )
        {
            Llave_Sala_2_Introducida = true;
        }
        if( index == 3 )
        {
            Llave_Sala_3_Introducida = true;
        }

    }

}
