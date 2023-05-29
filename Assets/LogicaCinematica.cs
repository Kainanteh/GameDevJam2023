using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LogicaCinematica : MonoBehaviour
{

    public AudioSource sourceMedieval;
    public AudioSource sourceHappy;
    public AudioSource sourceSad;

    public AudioSource playersource1;
    public AudioSource playersource2;

       public DisparadorSonidos disparadorSonidosScript;

       public AjustarAlphaImage ajustarAlphaImageScript;

    public void PlayMedieval()
    {

        sourceMedieval.Play();

    }

    public void StopMedieval()
    {

        sourceMedieval.Stop();

    }

    public void StopSourcePlayer()
    {

        playersource1.Stop();
        playersource2.Stop();

    }

    public void PlayHappy()
    {

        sourceHappy.Play();

    }

    public void PlaySad()
    {

        sourceSad.Play();

    }

        public void Recargar()
    {
        // Obtener el índice de la escena actual
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        // Recargar la escena utilizando su índice
        SceneManager.LoadScene(currentSceneIndex);
    }

        public void Disparosonido(int index)
    {

          disparadorSonidosScript.DispararSonido(index);

    }

    public void AjustarAlpha()
    {

        ajustarAlphaImageScript.IniciarFundidoNegro();

    }

}
