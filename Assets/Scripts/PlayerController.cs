using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float horizontal;
    private float vertical;
    private float speed = 8f;
    private bool isFacingRight = true;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Animator animator;
    [SerializeField] private Camera cam;
    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");

        //Flip();
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * speed, vertical * speed);
        if (horizontal != 0)
        {
            animator.SetFloat("Speed", Math.Abs(horizontal));
        }
        else if (vertical != 0)
        {
            animator.SetFloat("Speed", Math.Abs(vertical));
        }
        else
        {
            animator.SetFloat("Speed", 0f);
        }
        FlipAtMouse();
    }

    private void FlipAtMouse()
    {
        Vector2 mousePos = Input.mousePosition;
        int screenWidth = Screen.width / 2;
        if (mousePos.x > screenWidth && !isFacingRight)
        {
            isFacingRight = true;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
        else if (mousePos.x < screenWidth && isFacingRight)
        {
            isFacingRight = false;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }

    private void Flip()
    {
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }
}
