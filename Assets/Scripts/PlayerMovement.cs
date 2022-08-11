using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private bool isNormalized = true;
    private Rigidbody2D rb;
    private Animator animator;
    private static readonly int MoveX = Animator.StringToHash("moveX");
    private static readonly int MoveY = Animator.StringToHash("MoveY");

    private void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Vector2 movement;
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        if (isNormalized)
            movement = movement.normalized;
        if (movement != Vector2.zero)
            Move(movement);
    }

    private void Move(Vector2 movement)
    { 
        animator.SetFloat("moveX", movement.x);
        animator.SetFloat("moveY", movement.y);
        rb.MovePosition(rb.position + movement * speed * Time.deltaTime);
    }
}
