using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    public void Awake()
    {
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
