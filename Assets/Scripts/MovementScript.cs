using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementScript : MonoBehaviour
{
    public CharacterController controller;

    public float speed = 12f;
    public float gravity = -9.81f;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    Vector3 velocity;
    bool isGrounded;

    public float stamina = 10f;

    bool isRunning;
    bool isCrouched = false;


    void Update()
    {
        if(isRunning && stamina > 0 && !isCrouched)
        {
            speed = 20f;
            stamina -= 10 * Time.deltaTime;
            if (stamina < 0)
            {
                stamina = 0;
                isRunning = false;
            }
        } 
        if(!isRunning && !isCrouched)
        {
            speed = 12f;
        }
        if (isCrouched)
        {
            speed = 5f;
        }

        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            transform.localScale = new Vector3(1f, 0.75f, 1f);
            transform.position = new Vector3(transform.position.x, transform.position.y - 0.25f, transform.position.z);
            isCrouched = true;
        }
        if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
            transform.position = new Vector3(transform.position.x, transform.position.y + 0.25f, transform.position.z);
            isCrouched = false;
        }

        isRunning = Input.GetKey(KeyCode.LeftShift);
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if(isGrounded && velocity.y < 0 )
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        
        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }

}
