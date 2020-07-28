using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightArena : MonoBehaviour
{

    public int enemiesToKill = 2;
    public int enemiesKilled = 0;

    public GameObject[] spawners;

    public GameObject gates;

    bool finished = false;

    public bool showingNewObject = false;
    public GameObject newObject;

    public GameObject wave2;
    public GameObject wave3;

    private void Start()
    {
        gates.SetActive(false);

        if (showingNewObject)
        {
            newObject.SetActive(false);
        }

        //Buggy way of accounting for strangeness
        enemiesToKill *= 2;
    }

    private void Update()
    {
            if (enemiesKilled >= enemiesToKill)
            {
                //do some cool animation if we have the time

                gates.SetActive(false);
                finished = true;

                if (showingNewObject)
                {
                    newObject.SetActive(true);
                }
            }
    }

    public void killedAnEnemy()
    {
        enemiesKilled += 1;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            enemiesKilled = 0;

            if (!finished)
                gates.SetActive(true);
        }
     

    }

}
