using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shadowSwich : MonoBehaviour
{
    private bool IsShadowActive;

    [SerializeField]
    private GameObject OFF;
    [SerializeField]
    private GameObject ON;

    void Start()
    {
        IsShadowActive = false;
        OFF.SetActive(true);
        ON.SetActive(false);
    }

    public void Rpressed()
    {
        IsShadowActive = !IsShadowActive;
        if (IsShadowActive)
        {
            ShadowON();
        }
        else
        {
            ShadowOFF();
        }
    }

    private void ShadowON()
    {
        Debug.Log("Shadow Active");
        ON.SetActive(true);
        ON.transform.position = OFF.transform.position;
        ON.transform.rotation = OFF.transform.rotation;
        OFF.SetActive(false);
    }

    private void ShadowOFF()
    {
        Debug.Log("Shadow not Active");
        OFF.SetActive(true);
        ON.SetActive(false);
    }
}
