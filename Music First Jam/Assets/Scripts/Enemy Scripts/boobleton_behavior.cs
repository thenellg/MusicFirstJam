using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boobleton_behavior : enemy_behavior
{
    // Start is called before the first frame update

    [SerializeField] Rigidbody2D rb;

    public new bool inArenaCheck = true;
    GameObject arenaCheck;

    void Start()
    {
        Base_Initialize();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (inArenaCheck)
            inArena = true;
        else
            inArena = false;

        Check_Health();
        Take_Knockback();
        
        if(!invincible){
            Flip_Movement();
            Move_Agent_RigidBody(rb,move_speed);
        }
        
    }



    //On taking damage
    private void OnTriggerEnter2D(Collider2D other) {
        Take_Damage_From_Bullet(other);

        if (other.gameObject.tag == "Arena")
        {
            arena = other.gameObject;
        }
    }

    
}
