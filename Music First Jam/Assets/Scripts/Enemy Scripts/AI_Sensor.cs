using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_Sensor : MonoBehaviour
{
    // Start is called before the first frame update


    private GameObject player;
    private Collider2D agent_vision_collider;
    private bool agent_sees_player;
    private bool player_within_vision;
    private bool agent_on_ledge;
    [SerializeField] private float agent_height;
    [SerializeField] private string[] visionTags; 
    [SerializeField] private float ground_check_angle;
    [SerializeField] private bool agent_cares_about_ledges;
    void Start()
    {
        agent_sees_player = false;
        agent_on_ledge = false;
        player = GameObject.Find("Player"); //get a reference to the player so we can track him
        //get our collider
        if(!(agent_vision_collider = GetComponent<CircleCollider2D>())){
            agent_vision_collider = GetComponent<BoxCollider2D>();
        }

    }
    private void Update(){
        if(player_within_vision){
           agent_sees_player = Is_Player_In_Sight();
        }
        if(agent_cares_about_ledges){
            agent_on_ledge = Is_On_Ledge(Agent_Facing_Right());
        }
        
    }

    //This assums we're flipping by negating the x scale.
    public bool Agent_Facing_Right(){
        if(transform.parent.localScale.x > 0){
            return true;
        }
        return false;
    }

    public bool Agent_On_Ledge(){
        return agent_on_ledge;
    }

    private bool Is_Player_In_Sight(){
        int masks = LayerMask.GetMask("Terrain","Player"); //we only want to scan for these masks
        Vector3 dir =  player.transform.position-transform.position;
        RaycastHit2D hit = Physics2D.Raycast(transform.position, dir,Mathf.Infinity,masks);
        Debug.DrawRay(transform.position,dir,Color.red);
        Debug.Log(transform.parent.name + " sees " + hit.collider.tag);
        if (hit.collider.tag == "Player"  && dir.x < 10){
            return true;
        }
        else{
            return false;
        }
    }

    //casts a ray from 0,0 at a 45 degree angle, at the appropriate height, asking if there is terrain in front of it, walls need to be marked in this case
    public bool Is_On_Ledge(bool right){
        if(!agent_cares_about_ledges)
            return false;

        int masks = LayerMask.GetMask("Terrain","Wall"); //we only want to scan for these masks
        
        ground_check_angle = -25;
        if(right){
            ground_check_angle = 205;
        }
        float a = Mathf.Deg2Rad*(ground_check_angle); 
        Vector3 angle =  new Vector3(Mathf.Cos(a), Mathf.Sin(a), 0f); //get angle for right side
        RaycastHit2D hit = Physics2D.Raycast(transform.position, angle*agent_height, agent_height,masks);
        Debug.DrawRay(transform.position,angle*agent_height,Color.blue);
        if(hit){
            Debug.Log(hit.collider.name);
            if (hit.collider.tag == "Terrain"){
                Debug.Log("I see Ground in front of me");
                return false;
            }
            else if(hit.collider.tag == "Wall"){
                Debug.Log("I see a wall in front of me");
            }
            else
            {
                Debug.Log("I dont see Ground in front of me");
                return true;
            }
        }
        Debug.Log("I dont see Ground in front of me");
        return true; //nothing means we're on a ledge
        
    }
    //This function name is real shitty

    public Vector3 Get_Player_Position(){
        return player.transform.position;
    }
    public bool Get_Vision(){
        return agent_sees_player;
    }

    public bool Player_On_Right_Side(){
        if((transform.position.x - player.transform.position.x) > 0)
            return true;
        return false;
    }


    private void OnTriggerEnter2D(Collider2D other){
        if(other.tag == "Player"){
            player_within_vision = true;
        }
    }

   private void OnTriggerExit2D(Collider2D other) {
       if(other.tag == "Player"){
            agent_sees_player = false;
            player_within_vision = false;
        }
    }

/*    private void OnTriggerStay2D(Collider2D other) {
        if(other.tag == "Player"){
            agentSeesPlayer = true;
        }
    }
 */ 

    
}
