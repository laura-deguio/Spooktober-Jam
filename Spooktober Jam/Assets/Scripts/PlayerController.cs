using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private CharacterController controller;

    static Animator animator;

    public float speed = 3f;
    public float runningSpeed = 5f;
    public float rotationSpeed = 3f;

    private bool isRunning;
    private float isWalking;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();

    }

    private void Update()
    {
        transform.Rotate(0, Input.GetAxis("Horizontal") * rotationSpeed, 0);
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        float curSpeed = speed * Input.GetAxis("Vertical");

        isWalking = Input.GetAxis("Horizontal");
        isWalking = Input.GetAxis("Vertical");

        animator.SetFloat("isWalking", isWalking);


        controller.SimpleMove(forward * curSpeed);

        isRunning = Input.GetButton("Fire3");
        if (Input.GetButton("Fire3"))
        {
            animator.SetBool("isRunning", true);
            speed = runningSpeed;
        }
        else
        {
            animator.SetBool("isRunning", false);
            speed = 2;
        }

        animator.SetBool("isRunning", isRunning);
    }

}
