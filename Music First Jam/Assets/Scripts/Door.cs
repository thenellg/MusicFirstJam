using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    public int sceneNumber;
    public String newScene;

    public bool healthReset = false;
    public GameObject Player;

    public Animator curtain;
    public AudioSource music;

    public void changeScene()
    {

        if (healthReset)
        {
            PlayerPrefs.SetInt("Health", 3);

        }
        else
        {
            PlayerPrefs.SetInt("Health", Player.GetComponent<PlayerController>().playerHealth);
        }

        curtain.SetTrigger("curtainDown");

        StartCoroutine(AudioFadeOut.FadeOut(music, 1f));

        Invoke("loading",2.5f);
    }

    void loading()
    {
        SceneManager.LoadScene(newScene);
    }
}

