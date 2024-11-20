using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonController : MonoBehaviour
{

    CharacterController controller;
    Animator animator;
    Vector3 input, moveDirection;

    public float moveSpeed = 10;
    public float jumpHeight = 10;
    public float gravity = 9.81f;
    public float airControl = 10f;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        input = (transform.right * moveHorizontal + transform.forward * moveVertical).normalized;

        input *= moveSpeed;

        if (controller.isGrounded)
        {
            moveDirection = input;

            //we can jump
            if (Input.GetButton("Jump"))
            {
                moveDirection.y = Mathf.Sqrt(2 * jumpHeight * gravity);
            }
            else
            {
                moveDirection.y = 0.0f;
            }

        }
        else
        {
            input.y = moveDirection.y;
            moveDirection = Vector3.Lerp(moveDirection, input, airControl * Time.deltaTime);
        }

        moveDirection.y -= gravity * Time.deltaTime;

        controller.Move(moveDirection * Time.deltaTime);

        //rotate the character in camera direction when walking
        //if (input.magnitude > 0.01f)
        //{
        //    float cameraYawRotation = Camera.main.transform.eulerAngles.y;
        //    Quaternion newRotation = Quaternion.Euler(0f, cameraYawRotation, 0f);
        //    transform.rotation = Quaternion.Lerp(transform.rotation, newRotation, Time.deltaTime * 10);
        //}



        if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
            {
                animator.SetInteger("animState", 1); //walk
            }
            else
            {
                animator.SetInteger("animState", 0); //idle
            }
        }
    }

