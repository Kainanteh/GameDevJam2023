using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LlaveScriptCerradura : MonoBehaviour
{

    public LogicaCerraduras LogicaCerradurasScript;

    public int index;

    public void LLaveIntroducida_(  )
    {

        LogicaCerradurasScript.LLaveIntroducida(index);
        

    }


}
