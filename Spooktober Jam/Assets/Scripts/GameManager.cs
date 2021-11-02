using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public int candyLeft = 100;
    public TMP_Text candyText;

    public static GameManager instanceManager;

    // Start is called before the first frame update
    void Start()
    {
        instanceManager = this;
    }

    // Update is called once per frame
    void Update()
    {
        candyText.text = candyLeft.ToString();

        if (candyLeft <= 0)
        {
            Win();
        }
    }

    public void Win()
    {
        //Win condition
        SceneManager.LoadScene(3);
    }

    public void GameOver()
    {
        //Lose condition
        SceneManager.LoadScene(4);
    }

    public void Play()
    {
        SceneManager.LoadScene(1);
    }

    public void Menu()
    {
        SceneManager.LoadScene(0);
    }

    public void Quit()
    {
        Application.Quit();

    }

}
