using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpOne : MonoBehaviour
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
        if (Input.GetButton("Jump"))
        {
            Debug.Log("Boop!");
            jumpForce = Vector2.up * jumpStrength;
        }
        else
        {
            jumpForce = Vector2.zero;
        }
    }

    private void FixedUpdate()
    {
        rb.AddForce(jumpForce);
    }
}
