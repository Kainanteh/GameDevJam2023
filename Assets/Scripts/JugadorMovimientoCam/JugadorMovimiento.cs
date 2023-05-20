using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JugadorMovimiento : MonoBehaviour
{

    public float moveSpeed;

    public float groundDrag;

    public float playerHeight;
    public LayerMask sueloEtiqueta;
    bool ensuelo;


    public Transform orientacion;

    float horizontalInput;
    float verticalInput;

    Vector3 moveDirection;

    Rigidbody rb;



    void Start()
    {
        
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;

    }

    private void MyInput()
    {

        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");

    }


    void Update()
    {

        ensuelo = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.2f, sueloEtiqueta);

        MyInput();
        SpeedControl();

        if(ensuelo)
        {
            rb.drag = groundDrag;
        }
        else
        {
            rb.drag = 0;
        }

    }

    void FixedUpdate()
    {
     
        MovePlayer();

    }


    private void MovePlayer()
    {

        moveDirection = orientacion.forward * verticalInput + orientacion.right * horizontalInput;

        rb.AddForce(moveDirection.normalized * moveSpeed * 10f, ForceMode.Force);

    }

    private void SpeedControl()
    {

        Vector3 flatVel = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        if(flatVel.magnitude > moveSpeed)
        {
            Vector3 limitedVel = flatVel.normalized * moveSpeed;
            rb.velocity = new Vector3(limitedVel.x, rb.velocity.y, limitedVel.z);
        }

    }

}
