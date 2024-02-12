using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeactivateColliderOnTrigger : MonoBehaviour
{
    [SerializeField] private Collider targetCollider;

    [SerializeField] private bool isTriggered;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !isTriggered)
        {
            targetCollider.enabled = false;
            isTriggered = true;
            Debug.Log("log");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") && isTriggered)
        {
            targetCollider.enabled = true;
            isTriggered = false;
        }
    }
}