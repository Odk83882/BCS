using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class copyRotation : MonoBehaviour
{
    public GameObject followedObject;

    // Update is called once per frame
    void Update()
    {
        transform.rotation = followedObject.transform.rotation;
    }
}
