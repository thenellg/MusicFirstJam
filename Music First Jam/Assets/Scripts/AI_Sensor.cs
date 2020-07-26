using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_Sensor : MonoBehaviour
{
    // Start is called before the first frame update


    private GameObject player;
    private Collider2D agent_vision_collider;
    private bool agentSeesPlayer;
    private bool playerWithinVision;

    [SerializeField] private string[] visionTags; 
    void Start()
    {
        agentSeesPlayer = false;
        player = GameObject.FindGameObjectWithTag("Player"); //get a reference to the player so we can track him
        //get our collider
        if(!(agent_vision_collider = GetComponent<CircleCollider2D>())){
            agent_vision_collider = GetComponent<BoxCollider2D>();
        }

    }
    private void Update(){
        if(playerWithinVision){
            int masks = LayerMask.GetMask("Terrain","Player"); //we only want to scan for these masks
            Vector3 dir =  player.transform.position-transform.position;
            RaycastHit2D hit = Physics2D.Raycast(transform.position, dir,Mathf.Infinity,masks);
            Debug.DrawRay(transform.position,dir,Color.red);
            Debug.Log(hit.collider.name);
            if (hit.collider.tag == "Player"){
                Debug.Log("f");
                agentSeesPlayer = true;
            }
            else{
                agentSeesPlayer = false;
            }
        }
    }

    public bool Get_Vision(){
        return agentSeesPlayer;
    }

    public bool Player_On_Right_Side(){
        if((transform.position.x - player.transform.position.x) > 0)
            return true;
        return false;
    }


    private void OnTriggerEnter2D(Collider2D other){
        if(other.tag == "Player"){
            playerWithinVision = true;
        }
    }

   private void OnTriggerExit2D(Collider2D other) {
       if(other.tag == "Player"){
            agentSeesPlayer = false;
            playerWithinVision = false;
        }
    }

/*    private void OnTriggerStay2D(Collider2D other) {
        if(other.tag == "Player"){
            agentSeesPlayer = true;
        }
    }
 */ 
}
