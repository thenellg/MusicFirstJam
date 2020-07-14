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
        if (noteNum == 1)
        {
            Instantiate(Note1, firePoint.position, firePoint.rotation);
        }
        else if (noteNum == 2)
        {
            Instantiate(Note2, firePoint.position, firePoint.rotation);
        }
        else if (noteNum == 3)
        {
            Instantiate(Note3, firePoint.position, firePoint.rotation);
        }
        else if (noteNum == 4)
        {
            Instantiate(Note4, firePoint.position, firePoint.rotation);
        }
    }
}
