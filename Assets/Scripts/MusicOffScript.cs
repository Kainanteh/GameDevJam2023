using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicOffScript : MonoBehaviour
{
    public LayerMask skyLayer;
    public float raycastDistance = Mathf.Infinity;

    public AudioSource audioSource;
    public AudioSource audioSourcemal;
    public float targetVolume;
    public float transitionSpeed = 1f;

    public float currentVolume;
    public float currentVolumemal;

    public float volumen;

        public float targetVolumemal;



    void Start()
    {
        currentVolume = audioSource.volume;
        currentVolumemal = audioSourcemal.volume;
    }

    void Update()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, raycastDistance, skyLayer))
        {
            targetVolume = 0f;
            targetVolumemal = volumen;
        }
        else
        {
            targetVolume = volumen;
            targetVolumemal = 0f;
        }

    
        currentVolume = Mathf.Lerp(currentVolume, targetVolume, transitionSpeed * Time.deltaTime);
        currentVolumemal = Mathf.Lerp(currentVolumemal, targetVolumemal, transitionSpeed * Time.deltaTime);

        audioSource.volume = currentVolume;
        audioSourcemal.volume = currentVolumemal;
    }

}
