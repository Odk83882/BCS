using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KillPlayer : MonoBehaviour
{
    public GameObject player;
    public Transform respownPoint;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter(Collision other)
    {
        Debug.Log("fortinit");
        if (other.gameObject.CompareTag("PlayerDeath"))
        {
            Debug.Log("dfghj");
            Scene currentScene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(currentScene.name);
            player.transform.position = respownPoint.position;
        }
    }

}
