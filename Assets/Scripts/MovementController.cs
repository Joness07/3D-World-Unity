using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    public CharacterController controller;

    public float speed = 12f;
    public float gravity = -9.81f;
    public float jumpForce = 3f;
    Vector3 velocity;

    public Transform groundCheck;
    public float groundDist = 0.4f;
    public LayerMask groundLayer;

    private Animator anim;

    public float x, z, y;

    public bool isGrounded;

    private void Start()
    {
        anim = GetComponentInChildren<Animator>();
    }
    private void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDist, groundLayer);

        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        x = Input.GetAxis("Horizontal");
        z = Input.GetAxis("Vertical");

        y = velocity.y;

        anim.SetFloat("yVel", y);

        if(x == 0 && z == 0)
        {
            anim.SetBool("isIdle", true);
            anim.SetBool("isRunning", false);
        }
        else
        {
            anim.SetBool("isIdle", false);
            anim.SetBool("isRunning", true );
        }

        anim.SetFloat("Horizontal", x);
        anim.SetFloat("Vertical", z);

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpForce * -2f * gravity);
            anim.SetBool("isJump", true);
        }

        if (Input.GetKeyDown(KeyCode.K))
        {

        }

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);

    }



}
