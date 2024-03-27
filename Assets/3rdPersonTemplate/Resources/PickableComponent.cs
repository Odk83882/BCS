using UnityEngine;


public class PickableComponent : MonoBehaviour
{

    public int layerNumber = 8;

    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == layerNumber )
        {
            HideObject();
        }
    }

    private void HideObject()
    {
        this.gameObject.SetActive(false);
    }
}