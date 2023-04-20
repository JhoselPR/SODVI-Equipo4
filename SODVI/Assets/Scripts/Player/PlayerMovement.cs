using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController characterController;
    public float speed = 10f;
    public float JumpHeight = 3f;
    private float gravity = -10f;
    public Transform groundCheck;
    public float sphereRadius = 0.3f;
    public LayerMask groundMask;
    bool isGrounded;

    Vector3 velocity;
    void Update()
    {
        //Suelo
        isGrounded = Physics.CheckSphere(groundCheck.position,sphereRadius,groundMask);
        if (isGrounded && velocity.y < 0){
            velocity.y = -2f;
        }

        //Movimiento
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        Vector3 move = transform.right*x+transform.forward*z;
        
        //Salto
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            velocity.y = Mathf.Sqrt(JumpHeight * -2 * gravity);
        }

        characterController.Move(move*speed*Time.deltaTime);

        //Gravedad
        velocity.y += gravity*Time.deltaTime;
        characterController.Move(velocity*Time.deltaTime);
    }
}