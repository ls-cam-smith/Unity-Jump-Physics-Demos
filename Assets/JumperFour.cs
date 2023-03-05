using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumperFour : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] private float jumpStrength = 1000;

    private bool allowJumping = true;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump") & allowJumping)
        {
            Debug.Log("Boop! 2");
            rb.AddForce(transform.up * jumpStrength);
            StartCoroutine(DisableJumpUntilLanding());
        }
    }

    //private void FixedUpdate()
    //{
    //    if (Input.GetButton("Jump") & allowJumping)
    //    {
    //        var jumpForce = transform.up * jumpStrengthContinuous * Time.deltaTime;
    //        rb.AddForce(jumpForce);
    //    }
    //}

    private bool IsMoving()
    {
        return rb.velocity.magnitude > 0.1f;
    }

    private IEnumerator DisableJumpUntilLanding()
    {
        allowJumping = false;
        Debug.Log("Waiting..");

        yield return new WaitUntil(() => !IsMoving());
        allowJumping = true;
    } 
}
