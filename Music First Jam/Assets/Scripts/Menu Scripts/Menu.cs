using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public GameObject pauseMenu;
    bool menuShowing = false;

    public GameObject resumeButton;
    public GameObject exitButton;

    public GameObject normalUI;

    // Start is called before the first frame update
    void Start()
    {
        pauseMenu.SetActive(false);   
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            pauseGame();
            Debug.Log("test");
        }

        if (menuShowing)
        {
            if (Input.GetButtonDown("Fire3"))
            {
                pauseGame();
            }
        }

    }

    public void pauseGame()
    {
       if (!menuShowing)
        {
            pauseMenu.SetActive(true);
            normalUI.SetActive(false);
            Time.timeScale = 0f;

            EventSystem.current.SetSelectedGameObject(null);
            EventSystem.current.SetSelectedGameObject(resumeButton);

            menuShowing = true;
        }
        else
        {
            pauseMenu.SetActive(false);
            normalUI.SetActive(true); 
            Time.timeScale = 1f;

            EventSystem.current.SetSelectedGameObject(null);

            menuShowing = false;
        }
    }

    public void exitToMenu()
    {
        //put whatever the correct number is here
        SceneManager.LoadScene(0);
    }
}
