using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{

    public float speed = 6f;
    public float jumpSpeed = 15f;
    public float gravity = 20f;
    public float crouchSpeed = 10f;
    private Vector2 moveDirection = Vector2.zero;
    private Animator animator;

    private CharacterController controller;
    private SpriteRenderer sprite;

    void Start() {
        controller = GetComponent<CharacterController>();
        sprite = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        float horizontal = Input.GetAxis("Horizontal");
        moveDirection.x = horizontal * speed;
        moveDirection = transform.TransformDirection(moveDirection);

        if (controller.isGrounded) {
            if (Input.GetButton("Jump")) {
                moveDirection.y = jumpSpeed;
            }
        } else {
            moveDirection.y -= gravity * Time.deltaTime;
        }
        if (moveDirection.x < 0) {
            sprite.flipX = true;
        } else if (moveDirection.x > 0) {
            sprite.flipX = false;
        }

        controller.Move(moveDirection * Time.deltaTime);

        // Walk-Animation
        Debug.Log(moveDirection);
        if(moveDirection == Vector2.zero || !controller.isGrounded) {
            animator.SetFloat("Speed", 0);
		} else { 
            animator.SetFloat("Speed", Mathf.Abs(moveDirection.x));
		}
    }
}
