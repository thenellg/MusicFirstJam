using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LanternTimer : MonoBehaviour
{
    public GameObject darkness;

    [SerializeField]
    float timer;

    Color temp, tempA;

    private void Update()
    {
        //timer = darkness.GetComponent<SpriteRenderer>().color.a;
    }

    private void FixedUpdate()
    {
        timer = darkness.GetComponent<SpriteRenderer>().color.a;
    }

    public void startTimer()
    {
        temp = darkness.GetComponent<SpriteRenderer>().color;
        temp.a = 0;
        darkness.GetComponent<SpriteRenderer>().color = temp;
        Invoke("counter", 2f);
    }


    void counter()
    {
        tempA = darkness.GetComponent<SpriteRenderer>().color;
        tempA.a = tempA.a + 0.1f;
        darkness.GetComponent<SpriteRenderer>().color = tempA;

        if (tempA.a < 1f)
        {
            Invoke("counter", 2f);
        }
    }

    public void holdTimer()
    {
        timer = 0;
    }

}
