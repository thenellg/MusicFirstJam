using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    public GameObject player;

    public Image showingHealth;
    public Sprite[] healthOptions = new Sprite[4];

    void FixedUpdate()
    {
        int index = player.GetComponent<PlayerController>().playerHealth;
        showingHealth.sprite = healthOptions[index];
    }
}
