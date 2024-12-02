using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class Player : MonoBehaviour
{
    public float Speed = 3f;
    public float rotationSpeed = 360f;


    public float runMultiplier = 2f;

    private bool isAttacking = false;


    private float gravity = -9.8f;


    Vector3 moveDirection;

    CharacterController characterController;
    Animator animator;


    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        animator = GetComponentInChildren<Animator>();


    }

    // Update is called once per frame
    void Update()
    {
    
        if (!isAttacking && characterController.isGrounded)
        {
            float xMove = Input.GetAxis("Horizontal");
            float zMove = Input.GetAxis("Vertical");
            


            // �޸���
            if (Input.GetKey(KeyCode.LeftShift) && moveDirection.sqrMagnitude > 0.01f)
            {
                moveDirection = new Vector3(xMove, 0, zMove) * Speed * runMultiplier;    // 2��
                animator.SetBool("Run", true);
            }
            else
            {
                moveDirection = new Vector3(xMove, 0, zMove) * Speed;
                animator.SetBool("Run", false);
            }


            // ȸ��
            if (moveDirection.sqrMagnitude > 0.01f)
            {
                Quaternion toRotation = Quaternion.LookRotation(moveDirection, Vector3.up);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
            }

            // ����
            if (Input.GetButtonDown("Jump") && characterController.isGrounded)
            {
                moveDirection.y = 5f;
                animator.SetTrigger("Jump");
            }


            animator.SetFloat("Speed", characterController.velocity.magnitude);
        }

        moveDirection.y += gravity * Time.deltaTime;

        characterController.Move(moveDirection  * Time.deltaTime);

        Attack();


        /*if (characterController.isGrounded)
        {
            Debug.Log("�ٴ� o");
        }
        else
        {
            Debug.Log("�ٴ� x");
        }*/
    }


    void Attack()
    {
        if (Input.GetMouseButtonDown(0) && !isAttacking)
        {
            isAttacking = true;
            animator.SetTrigger("Attacking");
        }
    }


    void AttackAnimaitionEnd()
    {
        isAttacking = false;
    }

}
