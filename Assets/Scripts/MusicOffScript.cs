using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicOffScript : MonoBehaviour
{
    public LayerMask skyLayer;
    public float raycastDistance = Mathf.Infinity;

    public AudioSource audioSource;

    public float volumen;

    void Update()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, raycastDistance, skyLayer))
        {

            audioSource.volume = 0;
           
    
        }
        else
        {
            audioSource.volume = volumen;
        }     
    }
}
