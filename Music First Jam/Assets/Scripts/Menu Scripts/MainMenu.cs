using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Animator curtain;
    public Image curtainObject;

    public void Start()
    {
        Color temp = curtainObject.color;
        temp.a = 0;
        curtainObject.color = temp;
    }

    public void StartGame()
    {
        Color temp = curtainObject.color;
        temp.a = 1;
        curtainObject.color = temp;

        PlayerPrefs.SetInt("Graveyard", 0);
        PlayerPrefs.SetInt("Dining", 0);
        PlayerPrefs.SetInt("Arcade", 0);
        PlayerPrefs.SetInt("Library", 0);
        PlayerPrefs.SetInt("Attic", 0);

        curtain.SetTrigger("curtainDown");
        Invoke("loading", 2.5f);
    }

    void loading()
    {
        SceneManager.LoadScene(1);
    }

    public void endGame()
    {
        Application.Quit();
    }


    public void tutorial()
    {
        SceneManager.LoadScene(2);
    }
}
