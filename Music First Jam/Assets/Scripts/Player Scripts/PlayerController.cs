using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    //object controller and controller support
    public GameObject objectController;
    //ControllerSupport controls;

    //Movement Variables
    public CharacterController2D controller;
    float horizontalMovement = 0f;
    public float moveSpeed = 40f;
    bool jump = false;
    bool crouch = false;

    //Door variables
    public GameObject buttonInteract;
    [SerializeField] bool inDoor = false;
    int sceneChange = 0;
    GameObject door;

    //Animation variables
    public Animator animator;
    bool doubleJump = false;

    public Animator note;

    //Health variables
    public int playerHealth = 3;
    bool invincible = false;
    public Color damage = new Color(121, 121, 121, 255);
    public Color normal = new Color(255, 255, 255, 255);

    //Knockback
    public float knockback;
    public float knockbackLength;
    public float knockbackCount;
    public bool knockFromRight;

    //Music variable
    public AudioSource music;

    public void Awake()
    {
        buttonInteract.SetActive(false);

        StartCoroutine(AudioFadeOut.FadeIn(music, 1f));

        inDoor = false;
    }

    public void Update()
    {

        if (knockbackCount <= 0) {
            horizontalMovement = Input.GetAxisRaw("Horizontal") * moveSpeed;
        }
        else
        {
            if (knockFromRight)
                GetComponent<Rigidbody2D>().velocity = new Vector2(-20, knockback);
            else
                GetComponent<Rigidbody2D>().velocity = new Vector2(20, knockback);

            knockbackCount -= Time.deltaTime;
        }

        animator.SetFloat("Speed", Mathf.Abs(horizontalMovement));

        //vertVelocity
        if (GetComponent<Rigidbody2D>().velocity.y >= 0)
        {
            animator.SetBool("vertMovement", true);
        }
        else
        {
            animator.SetBool("vertMovement", false);
        }

        //Jump
        if (Input.GetButtonDown("Jump"))
        {
            if (doubleJump == false)
            {
                jump = true;
                animator.SetBool("isJumping", true);
            }
        }

        if (Input.GetButtonDown("Fire1"))
        {

            animator.SetTrigger("isAttacking");
        }

        //Change Instruments
        if (Input.GetButtonDown("Fire2"))
        {
            ChangeInstruments();
            note.SetTrigger("ChangedNote");
        }

        if (inDoor == true)
        {
            if (Input.GetButtonDown("Fire3"))
            {
                //get scene number from door script and change to scene
                door.gameObject.GetComponent<Door>().changeScene();
            }
        }

        if (invincible)
        {
            this.GetComponent<SpriteRenderer>().color = damage;
        }
        else
        {
            this.GetComponent<SpriteRenderer>().color = normal;
        }

        if (playerHealth <= 0)
        {
            GameOver();
        }
    }

    public void onLanding()
    {
        animator.SetBool("isJumping", false);
    }

    private void FixedUpdate()
    {
        controller.Move(horizontalMovement * Time.fixedDeltaTime, false, jump);
        jump = false;

    }

    void ChangeInstruments()
    {
        if (objectController.GetComponent<BlockChanging>().showingGroup != 4)
        {
            objectController.GetComponent<BlockChanging>().showingGroup++;
        }
        else
        {
            objectController.GetComponent<BlockChanging>().showingGroup = 1;
        }
    }

    void GameOver()
    {
        //Whatever fancy game over stuff

        PlayerPrefs.SetInt("Health", 3);
        SceneManager.LoadScene(1);
    }

    void invincibleOff()
    {
        invincible = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Door")
        {

            door = collision.gameObject;
            buttonInteract.SetActive(true);
            sceneChange = collision.gameObject.GetComponent<Door>().sceneNumber;
            inDoor = true;
        }
        if((collision.gameObject.tag == "EnemyAttack" && collision.gameObject.layer != 12 && invincible == false) || (collision.gameObject.tag == "Enemy" && collision.gameObject.layer != 12 && invincible == false)){
            Player_Take_Damage(1,collision.transform);
            Debug.Log(collision.gameObject.layer);
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if ((collision.gameObject.tag == "EnemyAttack" && invincible == false) || (collision.gameObject.tag == "Enemy" && invincible == false))
        {
            Debug.Log(collision.gameObject.layer);
            //Do damage, set buffer and set off animation
            Player_Take_Damage(1,collision.transform);
            //Knockback   
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Door")
        {
            buttonInteract.SetActive(false);
            inDoor = false;
        }
        
    }

    //Enemies should be able to call this function to deal damage to our boy
    public void Player_Take_Damage(int n, Transform collision){
                    //Do damage, set buffer and set off animation
            playerHealth -= 1;
            invincible = true;
            Invoke("invincibleOff", 1f);
            animator.SetTrigger("isHurt");

            //Knockback
            knockbackCount = knockbackLength;
            if (collision.position.x > transform.position.x)
            {
                knockFromRight = true;
            }
            else
            {
                knockFromRight = false;
            }

            if (playerHealth <= 0)
            {
                GameOver();
            }

    }
    
    /*
    void OnEnable()
    {
        controls.Gameplay.Enable();
    }

    void OnDisable()
    {
        controls.Gameplay.Disable();
    }
    */
}
