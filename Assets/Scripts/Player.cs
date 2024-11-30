using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float Speed = 3f;
    public float rotationSpeed = 360f;

    bool isRunning = false;
    float runMultiplier = 2f;

    private float gravity = -9.8f;

    CharacterController characterController;
    Animator animator;

    bool isAttacking = false;

    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        animator = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        float xMove = Input.GetAxis("Horizontal");
        float zMove = Input.GetAxis("Vertical");
        Vector3 moveDirection = new Vector3(xMove, 0, zMove);

        // 중력
        if (!characterController.isGrounded)
        {
            moveDirection.y += gravity * Time.deltaTime;
        }
        else
        {
            moveDirection.y = 0;
        }

        // 달리기
        float currentSpeed = Speed;

        if (Input.GetKey(KeyCode.LeftShift) && moveDirection.sqrMagnitude > 0.01f)
        {
            currentSpeed *= runMultiplier;    // 2배
            animator.SetBool("Run", true); 
        }
        else
        {
            animator.SetBool("Run", false); 
        }

        if (Input.GetMouseButtonDown(0))
        {
            isAttacking = true;
            animator.SetTrigger("Attacking");
            currentSpeed = 0f;
        }


        if (!isAttacking)
        {
            characterController.Move(moveDirection * currentSpeed * Time.deltaTime);
        }

        animator.SetFloat("Speed", characterController.velocity.magnitude);

        if (moveDirection.sqrMagnitude > 0.01f)
        {
            Quaternion toRotation = Quaternion.LookRotation(moveDirection, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
        }
    }

    void AttackAnimaitionEnd()
    {
        isAttacking = false;
    }
}
