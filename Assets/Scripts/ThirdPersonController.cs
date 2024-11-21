using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonController : MonoBehaviour
{

    CharacterController controller;
    Animator animator;
    Vector3 input, moveDirection;

    public float moveSpeed = 5f;
    //public float jumpHeight = 10;
    public float gravity = 9.81f;
    //public float airControl = 10f;
    public float turnSpeed = 180f;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //moveDirection.y -= gravity * Time.deltaTime;

        transform.Rotate(0, Input.GetAxis("Horizontal") * turnSpeed * Time.deltaTime, 0);
        moveDirection = transform.forward * Input.GetAxis("Vertical") * moveSpeed;

        moveDirection.y -= gravity * Time.deltaTime;


        controller.Move(moveDirection * Time.deltaTime - Vector3.up * 0.1f);



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

