using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


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
    bool inDoor = false;
    int sceneChange = 0;

    public void Awake()
    {
        buttonInteract.SetActive(false);
        /*
        //Trying the new input system. Doesn't work for continuous movement yet so I'm
        //scrapping the idea
        controls = new ControllerSupport();

        //repeat this formula for other controls
        controls.Gameplay.changeInstrument.performed += ctx => ChangeInstruments();
        controls.Gameplay.leftMove.performed += ctx => moveLeft();
        controls.Gameplay.rightMove.performed += ctx => moveRight();
        */
    }

    public void Update()
    {
        horizontalMovement = Input.GetAxisRaw("Horizontal") * moveSpeed;

        //Jump
        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
        }

        //Change Instruments
        if (Input.GetButtonDown("Fire2"))
        {
            ChangeInstruments();
        }

        if (inDoor == true)
        {
            if (Input.GetButtonDown("Fire3"))
            {
                //get scene number from door script and change to scene
                SceneManager.LoadScene(sceneChange);
            }
        }
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Door")
        {
            buttonInteract.SetActive(true);
            sceneChange = collision.gameObject.GetComponent<Door>().sceneNumber;
            inDoor = true;
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
