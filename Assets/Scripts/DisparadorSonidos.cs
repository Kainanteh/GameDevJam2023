using System.Collections;
using UnityEngine;

public class DisparadorSonidos : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip[] audioClips;
    public float minDelay = 0.1f;
    public float maxDelay = 0.5f;

    private Coroutine soundCoroutine;

    private void Start()
    {
        audioSource.playOnAwake = false;
    }



    public void DispararSonido(int index)
    {
    
            // Generar un índice aleatorio para seleccionar un AudioClip
 
            AudioClip audioClip = audioClips[index];

            // Reproducir el AudioClip
            audioSource.PlayOneShot(audioClip);



        
    }
}
