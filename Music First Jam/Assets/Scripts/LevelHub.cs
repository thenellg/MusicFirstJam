using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelHub : MonoBehaviour
{
    public int doorNum = 0;
    public TextMeshProUGUI phrase;

    public GameObject player;
    public CinemachineVirtualCamera virtualCam;

    public GameObject harp;
    public Sprite[] harpArt = new Sprite[6];
    
    public GameObject HealthUI;

    public GameObject[] levelGates = new GameObject[4];

    [SerializeField] int[] levelsBeat;// = new int[5];
    [SerializeField] int numLevelsBeat = 0;

    private void Start()
    {
        levelsBeat = new int[5];

        numLevelsBeat = 0;

        getPlayerPrefs();

        //PlayerPrefs to get levels beat

        virtualCam.Follow = harp.transform;
        
        if (levelsBeat[4] != 1)
            Invoke("resetCam",4f);
        
        doorNum = 0;

        setPlayerPrefs();
        SetHarpImage();
    }

    void setPlayerPrefs()
    {
        PlayerPrefs.SetInt("Graveyard", levelsBeat[0]);
        PlayerPrefs.SetInt("Dining", levelsBeat[1]);
        PlayerPrefs.SetInt("Arcade", levelsBeat[2]);
        PlayerPrefs.SetInt("Library", levelsBeat[3]);
        PlayerPrefs.SetInt("Attic", levelsBeat[4]);
    }

    void getPlayerPrefs()
    {
        levelsBeat[0] = PlayerPrefs.GetInt("Graveyard", 0);
        levelsBeat[1] = PlayerPrefs.GetInt("Dining", 0);
        levelsBeat[2] = PlayerPrefs.GetInt("Arcade", 0);
        levelsBeat[3] = PlayerPrefs.GetInt("Library", 0);
        levelsBeat[4] = PlayerPrefs.GetInt("Attic", 0);

    }

    private void SetHarpImage()
    {
        if (levelsBeat[0] == 1)
        {
            levelGates[0].SetActive(false);
            numLevelsBeat++;
        }
        if (levelsBeat[1] == 1)
        {
            levelGates[1].SetActive(false);
            numLevelsBeat++;
        }
        if (levelsBeat[2] == 1)
        {
            levelGates[2].SetActive(false);
            numLevelsBeat++;
        }
        if (levelsBeat[3] == 1)
        {
            levelGates[3].SetActive(false);
            numLevelsBeat++;
        }
        if (levelsBeat[4] == 1)
        {
            numLevelsBeat++;
        }

        harp.GetComponent<SpriteRenderer>().sprite = harpArt[numLevelsBeat];

        
    }

    void resetCam()
    {
        virtualCam.Follow = player.transform;
    }

    private void FixedUpdate()
    {
        if (doorNum == 1)
        {
            phrase.text = "Graveyard (Tutorial)";
        }
        else if (doorNum == 2)
        {
            phrase.text = "Dining Room";
        }
        else if (doorNum == 3)
        {
            phrase.text = "Basement";
        }
        else if (doorNum == 4)
        {
            phrase.text = "Library";
        }
        else if (doorNum == 5)
        {
            phrase.text = "Attic";
        }
        else
        {
            phrase.text = "Find the missing strings";
        }
    }
}
