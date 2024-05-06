using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class victoryRoyal : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject _winScreen;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            //_winScreen.SetActive(true);
            Invoke("NextLevel", 3);
            

        }
    }
    void NextLevel()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.buildIndex + 1);
    }
    
}
