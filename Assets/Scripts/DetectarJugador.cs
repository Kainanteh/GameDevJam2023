using UnityEngine;

public class DetectarJugador : MonoBehaviour
{
    public Transform targetPosition;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.transform.position = targetPosition.position;
        }
    }
}
