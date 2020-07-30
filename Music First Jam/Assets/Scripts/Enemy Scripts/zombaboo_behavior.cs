using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zombaboo_behavior : enemy_behavior
{
    // Start is called before the first frame update
    [SerializeField] Rigidbody2D rb;
    [SerializeField] private Collider2D[] attack_boxes;
    [SerializeField] private float attack_range;
    private SpriteRenderer spriteRenderer;

    public bool inArenaCheck = true;
    GameObject arenaCheck;

    void Start()
    {
        Base_Initialize();
        rb = GetComponent<Rigidbody2D>();
        attack_boxes =  transform.GetChild(2).GetComponents<Collider2D>(); //get me the boxes idfiot
        spriteRenderer = GetComponent<SpriteRenderer>();
    }


    // Update is called once per frame
    void Update()
    {
        if (inArenaCheck)
        {
            inArena = true;
        }
        else
            inArena = false;


        Check_Health();
        Take_Knockback();
        Activate_HitBoxes();
        Decision_Tree();
    }



    //On taking damage
    private void OnTriggerEnter2D(Collider2D other) {
        Take_Damage_From_Bullet(other);

        if (other.gameObject.tag == "Arena")
        {
            arena = other.gameObject;
        }
    }

    private void Decision_Tree(){
        if(ai_sensor.Get_Vision()){
            //Debug.Log("zombaboo sees player");
            //If we see player...
            if(Mathf.Abs(ai_sensor.Get_Player_Position().x-transform.position.x) < attack_range){
                //if he's in range...
                Attack();
            }
            else{
                //if he's not in range
                MoveTowardsPlayer();
            }
        }
        else{
            //if we don't see the player
            Idle();
        }
    }
    
    private void MoveTowardsPlayer(){
        m_Animator.SetBool("idling",false);
        float dir = -1;
        if(!ai_sensor.Player_On_Right_Side()){
            dir = 1;
        }
        if(!invincible){
            Move_Agent_RigidBody(rb,move_speed*dir);
            Flip_Movement();
        }
    }

    private void Attack(){
        m_Animator.SetBool("idling",false);
        m_Animator.SetTrigger("Attack");
    }
    private void Idle(){
        m_Animator.SetBool("idling",true);
    }

    private void Activate_HitBoxes(){
        string name = spriteRenderer.sprite.name;
        //Each sprite has it's own hitbox
        //disable each box
        foreach(Collider2D i in attack_boxes){
            i.enabled = false;
        }
        //enable one box based off name
        //Debug.Log(name);
        switch (name)
        {
            case "Zombaboo - attack_0":
                attack_boxes[0].enabled = true;
                break;
            case "Zombaboo - attack_4":
                attack_boxes[1].enabled = true;
                break;
            case "Zombaboo - attack_5":
                attack_boxes[2].enabled = true;
                break;
            case "Zombaboo - attack_7":
                attack_boxes[3].enabled = true;
                break;
           
        }

    }
    
}
