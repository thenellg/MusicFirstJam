using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class musicBank : MonoBehaviour
{
    public AudioClip soundSent;
    public AudioClip[] AttackBank = new AudioClip[32];
    public int soundSentIndex = 0;

    public void sendSound()
    {
        soundSent = AttackBank[soundSentIndex];
        
        if (soundSentIndex < 31){
            soundSentIndex++;
        }
        else
        {
            soundSentIndex = 0;
        }
    }


}
