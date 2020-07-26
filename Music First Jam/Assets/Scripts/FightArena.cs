using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightArena : MonoBehaviour
{

    public int enemiesToKill = 10;
    public int enemiesKilled = 0;

    public GameObject[] spawners;

    public GameObject gates;

    bool finished = false;

    private void Start()
    {
        gates.SetActive(false);
    }

    private void Update()
    {
            if (enemiesKilled >= enemiesToKill)
            {
                destroySpawners();

                //kill all enemies

                //do some cool animation if we have the time

                gates.SetActive(false);
                finished = true;
            }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            enemiesKilled = 0;

            if (!finished)
                gates.SetActive(true);
        }
     
        if (collision.tag == "Enemy")
        {
            collision.GetComponent<EnemyDamage>().inArena = true;
        }
    }

    void destroySpawners()
    {
        if (spawners.Length > 0)
        {
            foreach (GameObject bye in spawners)
            {
                Destroy(bye);
            }
        }
    }

}
