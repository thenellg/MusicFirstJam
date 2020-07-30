using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelHub : MonoBehaviour
{
    public int doorNum = 0;
    public TextMeshProUGUI phrase;

    public GameObject HealthUI;

    private void Start()
    {
        HealthUI.SetActive(false);
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
            phrase.text = "Pick a level";
        }
    }
}
