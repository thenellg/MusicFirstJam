using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireMusic : MonoBehaviour
{

    public Transform firePoint;
    public GameObject Note1;
    public GameObject Note2;
    public GameObject Note3;
    public GameObject Note4;
    int noteNum = 1;
    public GameObject objectController;
    public GameObject musicBank;

    // Update is called once per frame
    void Update()
    {
        noteNum = objectController.GetComponent<BlockChanging>().showingGroup;

        if (Input.GetButtonDown("Fire1"))
        {
            shootMusic();
        }   
    }

    void shootMusic()
    {
        musicBank.GetComponent<musicBank>().sendSound();

        if (noteNum == 1)
        {
            Instantiate(Note1, firePoint.position, firePoint.rotation);
            Note1.GetComponent<AudioSource>().clip = musicBank.GetComponent<musicBank>().soundSent;
        }
        else if (noteNum == 2)
        {
            Instantiate(Note2, firePoint.position, firePoint.rotation);
            Note2.GetComponent<AudioSource>().clip = musicBank.GetComponent<musicBank>().soundSent;
        }
        else if (noteNum == 3)
        {
            Instantiate(Note3, firePoint.position, firePoint.rotation);
            Note3.GetComponent<AudioSource>().clip = musicBank.GetComponent<musicBank>().soundSent;
        }
        else if (noteNum == 4)
        {
            Instantiate(Note4, firePoint.position, firePoint.rotation);
            Note4.GetComponent<AudioSource>().clip = musicBank.GetComponent<musicBank>().soundSent;
        }
    }
}
