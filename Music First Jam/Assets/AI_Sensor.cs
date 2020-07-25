using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_Sensor : MonoBehaviour
{
    // Start is called before the first frame update


    private GameObject player;
    private CircleCollider2D agent_vision;
    private bool agentSeesPlayer;
    void Start()
    {
        agentSeesPlayer = false;
        player = GameObject.FindGameObjectWithTag("Player"); //get a reference to the player so we can track him
    }

    public bool Get_Vision(){
        return agentSeesPlayer;
    }


    private void OnTriggerEnter2D(Collider2D other){
        if(other.tag == "Player"){
            agentSeesPlayer = true;
        }
    }

   private void OnTriggerExit2D(Collider2D other) {
       if(other.tag == "Player"){
            agentSeesPlayer = false;
        }
    }

/*    private void OnTriggerStay2D(Collider2D other) {
        if(other.tag == "Player"){
            agentSeesPlayer = true;
        }
    }
 */ 
}
