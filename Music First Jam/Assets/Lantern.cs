using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lantern : MonoBehaviour
{
    public GameObject darkness;
    Color darkColor;
    bool LanternOff;

    private void Start()
    {
        darkColor = darkness.GetComponent<SpriteRenderer>().color;
        Invoke("AddToCounter", 1f);
    }

    private void Update()
    {
        darkness.GetComponent<SpriteRenderer>().color = darkColor;

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            darkColor.a = 0;
            LanternOff = false;
            Invoke("resetDarkness", 1f);
        }
    }

    void AddToCounter()
    {
        if (LanternOff)
            darkColor.a = darkColor.a + 0.2f;

        Invoke("AddToCounter", 1f);

    }


    void resetDarkness()
    {
        LanternOff = true;
    }
}
