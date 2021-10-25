using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int candyLeft = 100;
    public Text candyText;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        candyText.text = candyLeft.ToString();

        if(candyLeft <= 0)
        {
            Win();
        }
    }

    public void Win()
    {
        //Win condition
        Debug.Log("Win");
    }

    public void GameOver()
    {
        //Lose condition
        Debug.Log("Lost");
    }
}
