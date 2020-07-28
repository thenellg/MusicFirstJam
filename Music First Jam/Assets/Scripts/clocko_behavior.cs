using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class clocko_behavior : MonoBehaviour
{
    // Start is called before the first frame update    private Animator m_Animator;
    private Animator m_Animator;
    private AI_Sensor ai_sensor;

    public BoxCollider2D hurtBox;
    private bool is_activated;
    [SerializeField] private float shot_interval;
    private float timer;
    bool invincible = false;
    [SerializeField] protected int health;

    [SerializeField] private GameObject bullet;
    [SerializeField] private float shot_delay;

    [SerializeField] private GameObject death_rattle;

    private bool facing_right;
    void Start()
    {
        facing_right = true;
        is_activated= false;
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
    void Update()
    {
        if(ai_sensor.Get_Vision()){ //if he see
            Activate();
        }
        else{ //if we're vibin but we don't see the player
            Deactivate();
        }

        if(is_activated){
            timer += Time.deltaTime;
            if(timer > shot_interval){
                m_Animator.SetTrigger("Shoot");
                Invoke("Shoot",shot_delay);
                timer = 0;
            }
        }
        
        Face_Player();
        if(health <= 0){
            Invoke("Die",0.25f);
        }
    }

    private void Activate(){
        m_Animator.SetBool("Activated",true);
        hurtBox.enabled = true; //turn on the hurt
        is_activated = true;
    }

    private void Deactivate(){
        m_Animator.SetBool("Activated",false);
        hurtBox.enabled = false; //turn off the hurt
        is_activated = false;
    }
    
    private void Shoot(){
        var rot = transform.rotation;
        Quaternion flip = new Quaternion(0,0,1,0);
        if(facing_right)
            rot *= flip;
        Instantiate(bullet, transform.position, rot);
        timer = 0;
    }

    private void Die(){
        Instantiate(death_rattle,transform.position,transform.rotation);
        Destroy(this.gameObject);
    }

    private void Face_Player(){
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

    void invincibleOff()
    {
        invincible = false;
        GetComponent<SpriteRenderer>().color = new Vector4(255,255,255,255);
    }

    //On taking damage
    private void OnTriggerEnter2D(Collider2D other) {
        Bullet projectile;
        if(other.tag == "Attack" && !invincible){
            if(projectile = other.GetComponent<Bullet>()){
                m_Animator.SetTrigger("Hurt");
                health -= projectile.damage;
                GetComponent<SpriteRenderer>().color = Color.grey;
                invincible = true;
                Invoke("invincibleOff",2.0f);
            }
            else{
                return;
            }
        }
    }

}
