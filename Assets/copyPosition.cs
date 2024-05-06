using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class copyPosition : MonoBehaviour
{
    private GameObject followedObject;

    [SerializeField]
    private int yOffset = 1;

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
        transform.position = followedObject.transform.position + new Vector3(0, yOffset, 0);
    }
}
