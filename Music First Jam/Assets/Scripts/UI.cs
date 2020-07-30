using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    public GameObject player;

    public Animator curtain;
    
    public Image showingHealth;
    public Sprite[] healthOptions = new Sprite[4];

    private void Start()
    {
        curtain.SetTrigger("curtainUp");
    }

    void FixedUpdate()
    {
        int index = player.GetComponent<PlayerController>().playerHealth;
        showingHealth.sprite = healthOptions[index];
    }
}
