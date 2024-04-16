using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class movingplatform : MonoBehaviour
{
    public Rigidbody rb;
    public float movingSpeed = 0.0001f;
    public bool rightleft = false;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();

    }
    // Update is called once per frame
    void Update()
    {
        if (rightleft)
        {
            transform.position = transform.position + new Vector3(movingSpeed, 0, 0);
        }else
        {
            transform.position = transform.position + new Vector3(0, 0, movingSpeed);
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Anchor")) 
        {
            movingSpeed = movingSpeed * -1;
        }
    }
}
