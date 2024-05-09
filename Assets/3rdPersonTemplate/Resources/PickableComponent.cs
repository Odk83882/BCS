using UnityEngine;


public class PickableComponent : MonoBehaviour
{

    public int layerNumber = 8;
    public GameObject StarCounter;
    
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == layerNumber )
        {
            HideObject();
        }
    }

    private void HideObject()
    {
        //StarCounter.addStar();
        this.gameObject.SetActive(false);
    }
}