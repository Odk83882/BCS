using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stamina : MonoBehaviour
{
    public float staminaPercentage = 0;
    public GameObject staminaBar;

    [SerializeField]
    private float PassiveStaminaRegen;
    [SerializeField]
    private bool cantStaminaRegenerate = false;
    private float timer = 0f;
    public float delayAmount;

    public shadowSwich shadowReference;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        staminaBar.GetComponent<RectTransform>().localPosition = new Vector2(310 + staminaPercentage * 2.9f, 450);
        staminaBar.GetComponent<RectTransform>().sizeDelta = new Vector2(staminaPercentage * 5.8f, 40);
        if(staminaPercentage > 100)
        {
            staminaPercentage = 100;
        }
        if (staminaPercentage < 0)
        {
            staminaPercentage = 0;
        }

        timer += Time.deltaTime;

        if(cantStaminaRegenerate == false)
        {
            if (timer >= delayAmount)
            {
                timer = 0f;
                staminaPercentage = staminaPercentage + PassiveStaminaRegen * 0.1f;
            }
        }
        

        if (Input.GetKeyDown("r"))
        {
            if (staminaPercentage > 33)
            {
                cantStaminaRegenerate = !cantStaminaRegenerate;
                if (cantStaminaRegenerate)
                {
                    staminaPercentage = staminaPercentage - 33;
                }
                shadowReference.Rpressed();
            }else if (staminaPercentage < 33 && cantStaminaRegenerate)
            {
                cantStaminaRegenerate = !cantStaminaRegenerate;
                shadowReference.Rpressed();
            }
        }
    }
}
