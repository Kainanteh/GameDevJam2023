using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogicaSalaFinal : MonoBehaviour
{

    public bool Activador1 = false;
    public bool Activador2 = false;
    public bool Activador3 = false;

    public Animator animator;
    public string booleanParameterName = "IsTrue";

    public DisparadorSonidos disparadorSonidosScript;

  

    public void AbrirPuertaFinal()
    {

        if(Activador1 == true && Activador2 == true && Activador3 == true)
        {
            animator.SetBool(booleanParameterName, true);
             disparadorSonidosScript.DispararSonido(5);
        }

    }
}
