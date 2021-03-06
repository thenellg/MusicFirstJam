﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Hole : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            //Add in a fade to black here and a small hold

            collision.gameObject.GetComponent<PlayerController>().playerHealth--;

            PlayerPrefs.SetInt("Health", collision.gameObject.GetComponent<PlayerController>().playerHealth);

            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        if (collision.tag == "Enemy")
        {
            collision.GetComponent<enemy_behavior>().Die();
        }
    }
}
