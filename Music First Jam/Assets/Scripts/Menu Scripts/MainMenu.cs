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

}
