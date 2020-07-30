using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelHubDoor : MonoBehaviour
{
    public int doorNum;
    public GameObject LevelHubController;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        LevelHubController.GetComponent<LevelHub>().doorNum = doorNum;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        LevelHubController.GetComponent<LevelHub>().doorNum = 0;
    }

}
