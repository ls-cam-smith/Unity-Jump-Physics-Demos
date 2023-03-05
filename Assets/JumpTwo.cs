using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpTwo : MonoBehaviour
{
    private Vector2 jumpForce = Vector2.zero;
    private Rigidbody2D rb;
    [SerializeField] private float jumpStrength = 1;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(IsMoving());
        if (Input.GetButtonDown("Jump") & !IsMoving())
        {
            Debug.Log("Boop! 2");
            jumpForce = Vector2.up * jumpStrength;
        }
    }

    private void FixedUpdate()
    {
        rb.AddForce(jumpForce);
        jumpForce = Vector2.zero;
    }

    private bool IsMoving()
    {
        return rb.velocity.magnitude > 0.1f;
    }
}
