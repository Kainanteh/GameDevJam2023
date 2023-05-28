using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LlaveScript : MonoBehaviour
{

    public LogicaCerraduras LogicaCerradurasScript;

    public int index;

    public void LLaveIntroducida( )
    {

        LogicaCerradurasScript.LLaveIntroducida(index);
        

    }


}
