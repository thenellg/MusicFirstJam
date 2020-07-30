using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Lantern : MonoBehaviour
{
    public GameObject LanternController;
    
    Color temp, tempA;
    bool LanternOff;

    private void Start()
    {
        Invoke("AddToCounter", 1f);
    }

    private void Update()
    {
        //darkness.GetComponent<SpriteRenderer>().color = darkColor;

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            LanternController.GetComponent<LanternTimer>().startTimer();
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            LanternController.GetComponent<LanternTimer>().holdTimer();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            LanternController.GetComponent<LanternTimer>().startTimer();
        }
    }

}
