using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;

    public float speed = 12f;
    public float gravity = -9.81f;
    public float jumpHeight = 5f;
    public Animator animator;
    public Transform groundCheck;
    private float groundDistance = 0.2f;
    public LayerMask groundMask;
    Vector3 velocity;
    bool isGrounded;
    public bool isRolling =false;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        if (isRolling == false)
        {

            isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
            if (isGrounded && velocity.y < 0)
            {
                velocity.y = -2f;
            }

            float x = Input.GetAxis("Horizontal");
            float z = Input.GetAxis("Vertical");


            Vector3 move = transform.right * x + transform.forward * z;
            if (Input.GetKeyDown(KeyCode.C) && isGrounded)
            {
                animator.SetFloat("Speed", 0f);
                animator.SetTrigger("RollRight");
                isRolling = true;
            }

            controller.Move(move * speed * Time.deltaTime);
            Vector3 horizontalVelocity = controller.velocity;
            horizontalVelocity = new Vector3(controller.velocity.x, 0, controller.velocity.z);
            float horizontalSpeed = horizontalVelocity.magnitude;

            if (horizontalSpeed > 0)
            {
                animator.SetFloat("Speed", 5f);
            }
            else
            {
                animator.SetFloat("Speed", 0f);
            }

            if (Input.GetButtonDown("Jump") && isGrounded)
            {
                animator.SetFloat("Speed", 0f);
                velocity.y = Mathf.Sqrt(jumpHeight * 2f);
                animator.SetTrigger("Jumped");
            }

            velocity.y += gravity * Time.deltaTime;
            controller.Move(velocity * Time.deltaTime);
        }

        if(isRolling==true)
        {
            controller.Move(transform.right *1.5f* Time.deltaTime);
        }
    }
}
