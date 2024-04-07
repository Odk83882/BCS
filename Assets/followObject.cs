using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followObject : MonoBehaviour
{
    private GameObject followedObject;

    [SerializeField]
    private int yOffset = 1;

    [SerializeField]
    private bool copyRotation = false;
    
    private void Awake()
    {
        if (followedObject == null)
        {
            followedObject = GameObject.FindGameObjectWithTag("Player");
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = followedObject.transform.position + new Vector3(0, yOffset, 0);
        if (copyRotation)
        {
            transform.rotation = followedObject.transform.rotation;
        }
        
    }
}
