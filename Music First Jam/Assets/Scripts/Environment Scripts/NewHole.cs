using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewHole : MonoBehaviour
{
    public Transform warpBackPoint;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            //Add in a fade to black here and a small hold

            collision.gameObject.GetComponent<PlayerController>().playerHealth--;

            if (collision.gameObject.GetComponent<PlayerController>().playerHealth <= 0)
            {
                collision.gameObject.GetComponent<PlayerController>().GameOver();
            }

            PlayerPrefs.SetInt("Health", collision.gameObject.GetComponent<PlayerController>().playerHealth);

            collision.transform.position = warpBackPoint.position;
        }

        if (collision.tag == "Enemy")
        {
            collision.GetComponent<enemy_behavior>().Die();
        }
    }
}
