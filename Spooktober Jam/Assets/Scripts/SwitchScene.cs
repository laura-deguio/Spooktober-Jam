using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchScene : MonoBehaviour
{

    void Start()
    {
        StartCoroutine(ChangeScene());
    }


    void Update()
    {
        
    }

    IEnumerator ChangeScene()
    {
        yield return new WaitForSeconds(3);

        SceneManager.LoadScene(2);

    }
}
