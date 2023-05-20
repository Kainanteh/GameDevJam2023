using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JugadorCam : MonoBehaviour
{
 
    public float sensX;
    public float sensY;

    public Transform orientacion;

    float xRotacion;
    float yRotacion;

    private void Start()
    {

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

    }

    private void Update()
    {

        float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * sensX;
        float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * sensX;

        yRotacion += mouseX;
        xRotacion -= mouseY;

        xRotacion = Mathf.Clamp(xRotacion, -90f, 90f);

        transform.rotation = Quaternion.Euler(xRotacion,yRotacion,0);
        orientacion.rotation = Quaternion.Euler(0, yRotacion , 0);

    }




}
