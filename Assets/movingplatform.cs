using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movingplatform : MonoBehaviour
{
    public Rigidbody rb;
    public int movingSpeed = 1;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();

    }

    void Awake() 
    {
        rb.velocity = new Vector3(0, 0, movingSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Anchor")) 
        {
            movingSpeed = movingSpeed * -1;
            rb.velocity = new Vector3(0, 0, movingSpeed);
        }
    }
}
