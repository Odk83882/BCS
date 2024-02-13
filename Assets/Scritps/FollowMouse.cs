using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class FollowMouse : MonoBehaviour
{
    private Vector3 rotateValue;
    private void Update()
    {
        rotateValue = new Vector3(mouseDeltaX * -1, 0, 0);
        transform.eulerAngles = transform.eulerAngles - rotateValue;

    }

    private float mouseDeltaX;
    private void OnRotateFlashlight(InputValue inputValue)
    {
        mouseDeltaX = inputValue.Get<float>();
    }
}
