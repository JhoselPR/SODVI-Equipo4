using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float Velocidad = 1.0f;
    public float RotationSpeed = 1.0f;
    public float JumpForce = 1.0f;
    private Rigidbody Physics;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        Physics = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //Movimiento
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        transform.Translate(new Vector3(horizontal, 0.0f, vertical)*Time.deltaTime*Velocidad);
    
        //Rotación
        float rotationY = Input.GetAxis("Mouse X");

        transform.Rotate(new Vector3(0, rotationY * Time.deltaTime * RotationSpeed, 0));            
    
        //Salto
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Physics.AddForce(new Vector3(0,JumpForce,0), ForceMode.Impulse);
        }    
    }
}