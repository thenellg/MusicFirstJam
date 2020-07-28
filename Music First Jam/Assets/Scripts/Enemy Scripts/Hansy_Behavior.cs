using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hansy_Behavior : MonoBehaviour
{
    // Start is called before the first frame update

    private Animator m_Animator;
    private AI_Sensor ai_sensor;

    public BoxCollider2D hurtBox;
    private bool is_vibing;

    public bool inArena = false;
    GameObject arena;

    void Start()
    {
        is_vibing = false;
        m_Animator = gameObject.GetComponent<Animator>();
        
        if(gameObject.GetComponentInChildren<AI_Sensor>()){
            ai_sensor = gameObject.GetComponentInChildren<AI_Sensor>(); //DFS children for the script
            hurtBox = gameObject.GetComponentInChildren<BoxCollider2D>();
            hurtBox.enabled = false; //turn off the hurt
        }
        else{
            Debug.Log("AI not attached to entity: " + this.name);
            Destroy(this.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(ai_sensor.Get_Vision()){ //if he see
            Start_Vibing();
        }
        else if (!ai_sensor.Get_Vision()){ //if we're vibin but we don't see the player
            Stop_Vibing();
        }
    }

    void Start_Vibing(){
        m_Animator.SetBool("is_vibing",true);
        hurtBox.enabled = true; //turn on the hurt
        is_vibing = true;
    }

    void Stop_Vibing(){
        m_Animator.SetBool("is_vibing",false);
        hurtBox.enabled = false; //turn off the hurt
        is_vibing = false;
    }

}
