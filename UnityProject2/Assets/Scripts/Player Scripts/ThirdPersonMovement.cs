using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonMovement : MonoBehaviour
{
    public CharacterController controller;
    public Transform cam;
    public Animator animator;
    public float speed = 6f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        animator = transform.GetChild(0).GetComponent<Animator>();
    }

    public bool hit = false;
    void Update()
    {
        characterMovement();
        applyGravity();
        manageAnimations();
        if(hit){
            animator.SetBool("isDead", hit);
            hit = false;    
        }
    }

    public float gravity = -0.981f;
    public float jumpHeight = 0.00001f;
    public Transform groundCheck;
    public float groundDistance;
    public LayerMask groundMask;
    bool isGrounded;
    Vector3 gravityVelocity;

    public void applyGravity()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);//checking if we are touching the ground

        if(isGrounded && gravityVelocity.y < 0)
        {
            gravityVelocity.y = -0.01f;
        }

        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            gravityVelocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        gravityVelocity.y += gravity * Time.deltaTime;
       
        controller.Move(gravityVelocity);
    }

    float turnSmoothVelocity;
    public void characterMovement()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        if(direction.magnitude >= 0.1f)//gets direction we are moving
        {
            float turnSmoothTime = 0.1f;

            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;//get angle we are moving at
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);//smoothens the angle so we are not jumping from direction to direction

            transform.rotation = Quaternion.Euler(0f, angle, 0f);
            //move
            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            controller.Move(moveDir.normalized * speed * Time.deltaTime);
        }
    }

    bool interacted;
    public void manageAnimations(){
        animator.SetBool("isInteracting", Input.GetKey("e"));
        animator.SetBool("isWalking", (Input.GetKey("w") || Input.GetKey("a") || Input.GetKey("s") || Input.GetKey("d")));//if movement keys are down, (wasd), and e is not down

    }


}
