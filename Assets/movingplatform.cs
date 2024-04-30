using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class movingplatform : MonoBehaviour
{
    public float movingSpeed = 1f;
    void Update()
    {
            transform.position = transform.position + transform.forward * movingSpeed * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Anchor")) 
        {
            movingSpeed = movingSpeed * -1;
        }
    }
}
