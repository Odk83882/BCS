using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    float Speed = 5;

    public float jumpHeight = 7f;
    public bool isGrounded;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (isGrounded)
        {
            if (Input.GetKey(KeyCode.W))
            {
                rb.AddForce(Vector3.up * jumpHeight);
            }
        }
      
    
        if (Input.GetKey(KeyCode.D))
            {
                transform.position += transform.right * Speed * Time.deltaTime;
            }
        else if (Input.GetKey(KeyCode.A))
            {
                transform.position -= transform.right * Speed * Time.deltaTime;
            }
    }


    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Ground")
        {
            isGrounded = true;
        }
    }

    void OnCollisionExit(Collision other)
    {
        if (other.gameObject.tag == "Ground")
        {
            isGrounded = false;
        }
    }
}
 