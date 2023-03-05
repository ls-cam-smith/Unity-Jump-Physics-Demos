using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumperThree : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] private float jumpStrengthInitial = 10000;
    [SerializeField] private float jumpStrengthContinuous = 250;
    [SerializeField] private float floatTime = 5;

    private bool allowFloating = false;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump") & !IsMoving())
        {
            Debug.Log("Boop! 2");
            rb.AddForce(transform.up * jumpStrengthInitial);
            allowFloating = true;
            StartCoroutine(DisableFloatingAfterTime(floatTime));
        }
    }

    private void FixedUpdate()
    {
        if (Input.GetButton("Jump") & allowFloating)
        {
            var jumpForce = transform.up * jumpStrengthContinuous * Time.deltaTime;
            rb.AddForce(jumpForce);
        }
    }

    private IEnumerator DisableFloatingAfterTime(float seconds)
    {
        Debug.Log("Waiting..");
        yield return new WaitForSeconds(seconds);
        Debug.Log("Setting floating to false");
        allowFloating = false;
        yield return null;

    }

    private bool IsMoving()
    {
        return rb.velocity.magnitude > 0.1f;
    }
}
