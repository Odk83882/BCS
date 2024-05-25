using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class copyPosition : MonoBehaviour
{
    public GameObject followedObject;

    [SerializeField]
    private float xOffset;
    [SerializeField]
    private float yOffset;
    [SerializeField]
    private float zOffset;


    // Update is called once per frame
    void Update()
    {
        transform.position = followedObject.transform.position + new Vector3(xOffset, yOffset, zOffset);
    }
}
