using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpCandy : MonoBehaviour
{
    public GameManager gameManager;

    public AudioSource candyAudio;

    private void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            candyAudio.Play();
            GameManager.instanceManager.candyLeft -= 1;
            Destroy(gameObject, 0.2f);
        }
    }
}
