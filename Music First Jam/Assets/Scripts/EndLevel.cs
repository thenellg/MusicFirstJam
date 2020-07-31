using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndLevel : MonoBehaviour
{
    int levelID;

    public Animator playerAnim;
    public Animator stringAnim;
    public Animator curtain;

    public CinemachineVirtualCamera virtualCam;

    // Start is called before the first frame update
    void Start()
    {
        levelID = SceneManager.GetActiveScene().buildIndex;
        Debug.Log(levelID);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            virtualCam.Follow = transform;
            playerAnim.SetTrigger("EndLevel");
            stringAnim.SetTrigger("EndLevel");
            Invoke("curtainCall", 2f);
        }
    }

    void curtainCall()
    {
        setPlayerPref();
        curtain.SetTrigger("curtainDown");
        Invoke("loading", 2.5f);
    }

    void loading()
    {
        SceneManager.LoadScene(1);
    }

    void setPlayerPref()
    {
        if (levelID == 2)
        {
            PlayerPrefs.SetInt("Graveyard", 1);
        }
        else if (levelID == 4)
        {
            PlayerPrefs.SetInt("Dining", 1);
        }
        else if (levelID == 5)
        {
            PlayerPrefs.SetInt("Arcade", 1);
        }
        else if (levelID == 6)
        {
            PlayerPrefs.SetInt("Library", 1);
        }
        else if (levelID == 7)
        {
            PlayerPrefs.SetInt("Attic", 1);
        }
    }
}
