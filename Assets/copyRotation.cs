using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class copyRotation : MonoBehaviour
{
    private GameObject followedObject;

    private void Awake()
    {
        if (followedObject == null)
        {
            followedObject = GameObject.FindGameObjectWithTag("Player");
        }
    }
    // Update is called once per frame
    void Update()
    {
        transform.rotation = followedObject.transform.rotation;
    }
}
