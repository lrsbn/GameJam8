using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{

    public float speed = 6f;
    public float jumpSpeed = 8f;
    public float gravity = 20f;
    private Vector2 moveDirection = Vector2.zero;

    private CharacterController controller;
    private SpriteRenderer sprite;

    void Start() {
        controller = GetComponent<CharacterController>();
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (controller.isGrounded) {
            moveDirection = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
            moveDirection = transform.TransformDirection(moveDirection);

            moveDirection *= speed;

            if (Input.GetButton("Jump")) {
                moveDirection.y = jumpSpeed;
            }

            if (moveDirection.x < 0) {
                sprite.flipX = true;
            } else if (moveDirection.x > 0) {
                sprite.flipX = false;
            }
        }

        moveDirection.y -= gravity * Time.deltaTime;

        controller.Move(moveDirection * Time.deltaTime);
    }
}
