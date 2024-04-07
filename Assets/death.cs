using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.SceneManagement;

public class death : MonoBehaviour
{
    [SerializeField] private GameObject _deathScreen;
    public GameObject player;
    public Transform respownPoint;
    public float dalayTime = 3f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("kill"))
        {
            Debug.Log("dafgaf");
            _deathScreen.SetActive(true);
            Invoke("SceneReset", 3);
            

        }
    }

    void SceneReset()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name);
        player.transform.position = respownPoint.position;
    }
}
