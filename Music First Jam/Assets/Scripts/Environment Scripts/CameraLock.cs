using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLock : MonoBehaviour
{
    public CinemachineVirtualCamera virtualCam;
    public Transform normalFollow;
    public Transform lockPoint;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            virtualCam.Follow = lockPoint;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            virtualCam.Follow = normalFollow;
        }
    }
}
