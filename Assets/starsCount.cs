using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class starsCount : MonoBehaviour
{
    public int collectedStars;

    public GameObject zeroStars;
    public GameObject oneStar;
    public GameObject twoStars;
    public GameObject threeStars;

    private void addStar()
    {
        collectedStars = collectedStars + 1;
    }
    

    // Start is called before the first frame update
    void Start()
    {
        collectedStars = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (collectedStars == 0) 
        { 
            zeroStars.SetActive(true);
            oneStar.SetActive(false);
            twoStars.SetActive(false);
            threeStars.SetActive(false);
        }
        if (collectedStars == 1) 
        {
            zeroStars.SetActive(false);
            oneStar.SetActive(true);
            twoStars.SetActive(false);
            threeStars.SetActive(false);
        }
        if (collectedStars == 2) 
        {
            zeroStars.SetActive(false);
            oneStar.SetActive(false);
            twoStars.SetActive(true);
            threeStars.SetActive(false);
        }
        if (collectedStars == 3) 
        {
            zeroStars.SetActive(false);
            oneStar.SetActive(false);
            twoStars.SetActive(false);
            threeStars.SetActive(true);
        }
    }
}
