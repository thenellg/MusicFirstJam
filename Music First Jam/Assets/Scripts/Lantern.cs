using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Lantern : MonoBehaviour
{
    public GameObject LanternController;
    
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
