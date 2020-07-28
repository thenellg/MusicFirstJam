using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_behavior : MonoBehaviour
{
    // Start is called before the first frame update    private Animator m_Animator;
    protected Animator m_Animator;
    protected AI_Sensor ai_sensor;

    protected BoxCollider2D hurtBox;

    protected float timer = 0;
    protected bool invincible = false;
    [SerializeField] protected int health;

    [SerializeField] protected GameObject death_rattle;

    protected bool facing_right;
    protected bool moving_right;
    //Knockback
    [SerializeField] protected float knockbackCount;
    [SerializeField] protected float knockbackLength;
       
    [SerializeField] protected float knockback;
    [SerializeField] protected float move_speed;
    protected Vector3 m_Velocity = Vector3.zero;
    protected bool knockFromRight;

    public bool inArena = false;
    public GameObject arena;

    void Start()
    {
        Base_Initialize();
    }

    //basic inherited intitialization that all enemies will use
    protected void Base_Initialize(){
        moving_right = false;
        facing_right = false;
        invincible = false;
        m_Animator = gameObject.GetComponent<Animator>();
        
        if(gameObject.GetComponentInChildren<AI_Sensor>()){
            ai_sensor = gameObject.GetComponentInChildren<AI_Sensor>(); //DFS children for the script
            hurtBox = transform.GetChild(1).GetComponent<BoxCollider2D>(); //very hacky dont touch the child order lmao
        }
        else{
            Debug.Log("AI not attached to entity: " + this.name);
            GetComponent<SpriteRenderer>().color = Color.red; //sanity check in case ai is bonkered
        }
    }

    // Update is called once per frame

    protected void Check_Health(){
        if(health <= 0){
            Invoke("Die",0.25f);
        }
    }

    public void Die(){
        Instantiate(death_rattle,transform.position,transform.rotation);

        if (inArena)
        {
            arena.GetComponent<FightArena>().killedAnEnemy();
        }

        Destroy(this.gameObject);
    }

    protected void Face_Player(){
        var scale = transform.localScale;
        scale.x*=-1;
        if(ai_sensor.Player_On_Right_Side() && !facing_right){
            transform.localScale = scale;
            facing_right = true;
        }
        else if(!ai_sensor.Player_On_Right_Side() && facing_right){
            
            transform.localScale = scale;
            facing_right = false;
        }
    }

    protected void invincibleOff()
    {
        invincible = false;
        GetComponent<SpriteRenderer>().color = new Vector4(255,255,255,255);
    }
    //make sure that the trigger name is correct, we could edit this later as a parameter
    protected void Take_Damage_From_Bullet(Collider2D other){
        Bullet projectile;
        if(other.tag == "Attack" && !invincible){
            if(projectile = other.GetComponent<Bullet>()){
                m_Animator.SetTrigger("Hurt");
                health -= projectile.damage;
                GetComponent<SpriteRenderer>().color = Color.grey;
                invincible = true;
                Invoke("invincibleOff",1.0f);
            }
            else{
                return;
            }
            Set_Knockback(other);
        }
    }
    protected void Set_Knockback(Collider2D collision){
            knockbackCount = knockbackLength;
            if (collision.transform.position.x > transform.position.x)
            {
                knockFromRight = true;
            }
            else
            {
                knockFromRight = false;
            }
    }

    protected void Take_Knockback(){
        if(knockbackCount > 0){
            if (knockFromRight)
                GetComponent<Rigidbody2D>().velocity = new Vector2(-5, knockback);
            else
                GetComponent<Rigidbody2D>().velocity = new Vector2(5, knockback);

            knockbackCount -= Time.deltaTime;
        }
    }

    protected void Move_Agent_RigidBody(Rigidbody2D rb,float move){
        Vector3 targetVelocity = new Vector2(move * 10f, rb.velocity.y);
        // And then smoothing it out and applying it to the character
        rb.velocity = Vector3.SmoothDamp(rb.velocity, targetVelocity, ref m_Velocity, 0.5f);

        // If the input is moving the player right and the player is facing left...
        if (move < 0 && !ai_sensor.Agent_Facing_Right())
        {
            // ... flip the player.
            Flip_Sprite();
        }
        // Otherwise if the input is moving the player left and the player is facing right...
        else if (move > 0 && ai_sensor.Agent_Facing_Right())
        {
            // ... flip the player.
            Flip_Sprite();
        }
    }

    protected void Flip_Sprite(){
        Debug.Log("Flipping Sprite");
        var scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }

    protected void Flip_Movement(){
        if (ai_sensor.Agent_Facing_Right() && ai_sensor.Is_On_Ledge(true))
        {
            // ... flip the player.
            move_speed*= -1;
        }
        // Otherwise if the input is moving the player left and the player is facing right...
        else if (!ai_sensor.Agent_Facing_Right() && ai_sensor.Is_On_Ledge(false))
        {
            // ... flip the player.
            move_speed*= -1;
        }
    }

    //On taking damage
 
}
