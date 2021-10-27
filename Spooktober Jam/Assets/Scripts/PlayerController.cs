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

    public bool isRunning;
    private float isWalking;

    public Collider staffCollider;

    public bool isAttacking;

    private Coroutine attack;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();

        staffCollider.enabled = false;

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

        animator.SetBool("isRunning", isRunning);

        if (Input.GetButton("Fire3") && StaminaBar.instanceStamina.currentStamina >= 1)
        {
            StaminaBar.instanceStamina.UseStamina(0.1f);
            animator.SetBool("isRunning", true);
            speed = runningSpeed;
        }
        else
        {
            animator.SetBool("isRunning", false);
            speed = 6;
        }

        animator.SetBool("isAttacking", isAttacking);

        if (isAttacking == false)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                isAttacking = true;
                StartCoroutine(Attack());
                Debug.Log("Attacking");
            }
        }

    }
    private IEnumerator Attack()
    {
        while (isAttacking == true)
        {
            animator.SetBool("isAttacking", true);
            staffCollider.enabled = true;
            isAttacking = false;

            yield return new WaitForSeconds(0.9f);
        }

        animator.SetBool("isAttacking", false);
        staffCollider.enabled = false;

        attack = null;

    }
}
