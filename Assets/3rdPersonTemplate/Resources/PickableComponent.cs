using UnityEngine;


public class PickableComponent : MonoBehaviour
{

    public int layerNumber = 8;
    public starsCount starCounter;


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == layerNumber )
        {
            HideObject();
        }
    }

    private void HideObject()
    {
        starCounter.addStar();
        this.gameObject.SetActive(false);
    }
}