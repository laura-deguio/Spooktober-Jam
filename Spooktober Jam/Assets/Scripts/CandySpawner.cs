using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CandySpawner : MonoBehaviour
{
    public GameObject[] candy;

    public Transform[] spawner;

    public int totCandy = 2;
    public int totInvincibleCandy = 0;

    public int candyLimit = 10;
    public int invincibleCandyLimit = 2;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonUp("Fire1"))
        {
            Spawner();
        }
    }

    public void Spawner()
    {
        if (totCandy <= candyLimit)
        {
            if (totInvincibleCandy >= invincibleCandyLimit)
            {
                int ind = Random.Range(0, spawner.Length);
                Transform location = spawner[ind];

                Instantiate(candy[1], location.transform.position, transform.rotation);
                totCandy += 1;
            }
            else
            {
                int index = Random.Range(0, candy.Length);
                GameObject obj = candy[index];

                int ind = Random.Range(0, spawner.Length);
                Transform location = spawner[ind];

                Instantiate(obj, location.transform.position, transform.rotation);

                if (obj.gameObject.tag == "InvincibleCandy")
                {
                    totInvincibleCandy += 1;
                    totCandy += 1;
                }
                else
                {
                    totCandy += 1;
                }
            }

        }
        else
        {

        }
    }
}
