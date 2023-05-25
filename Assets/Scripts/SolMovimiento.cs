using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SolMovimiento : MonoBehaviour
{
    public Transform objetivo;
    public float cambioRotacionX = 0f;
    public float cambioRotacionY = 0f;
    public float cambioRotacionZ = 0f;

    private void Update()
    {
        // Calcular la dirección hacia el objetivo sin tener en cuenta la posición actual del objeto
        Vector3 direccion = objetivo.position - transform.position;
        direccion.y = 0f; // Opcional: Para que solo rote en el eje horizontal

        // Obtener la rotación basada en la dirección y aplicar los cambios deseados
        Quaternion rotacion = Quaternion.LookRotation(direccion);
        rotacion *= Quaternion.Euler(cambioRotacionX, cambioRotacionY, cambioRotacionZ);
        transform.rotation = rotacion;
    }
}
