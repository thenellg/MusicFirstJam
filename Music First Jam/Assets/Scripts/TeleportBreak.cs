using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportBreak : MonoBehaviour
{
    public GameObject teleportToBreak;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Destroy(teleportToBreak);
        }
    }
}
