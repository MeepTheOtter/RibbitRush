// Ribbit Rush-
// a script to move the frog around
// Copyright Team Nine 2020

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputMover : MonoBehaviour {

    
    InputManager.InputConfig playerController;
    Rigidbody rb;
    Animator anim;

    
    public float speed = 2f; // controls the speed the frog moves
    public Vector3 gravity = new Vector3(0, 10, 0); // affects the y axis downward
    public Vector3 jump = new Vector3(0, 50, 0); // affects the y axis upward when the jump command is issued
    private Vector3 input;

    public LayerMask layersToInteractWith;

    public int jumpJuice = 6; // controls how much jump the frog can do
    public float mult; // a multiplier for the jump command
    public bool isGrounded; // true, frog is on the ground. false, frog is not on the ground
    private bool isJumping; // used to determine if the frog is jumping or not
    private bool hasJumped;
    private Vector3 isMoving = new Vector3(0,0,0); // compared to the frogs current movement to determine if the frog is moving
    public Vector3 hop = new Vector3(0, -5, 0); // affects the y axis upward only while moving
    public int maxSpeed = 30; //  the max speed the frog can move
    public int hopTimer = 0;
    

    void Start () {        
        playerController = InputManager.player1;
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {

        if (hopTimer <= 0)
        {
            input = playerController.GetAxis1();
        }
        else if (hopTimer >= 20) input = isMoving;

        rb.velocity += input * Time.deltaTime * speed; // moves the frog based on input

        // limits the amount of movement you can do in the air
        if (isJumping){
            maxSpeed = 10;        
        }
        else maxSpeed = 20;

        // locks the speed from going over the max
        if (rb.velocity.x >= maxSpeed) rb.velocity = new Vector3(maxSpeed, rb.velocity.y, rb.velocity.z);
        if (rb.velocity.z >= maxSpeed) rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, maxSpeed);
        if (rb.velocity.x <= -maxSpeed) rb.velocity = new Vector3(-maxSpeed, rb.velocity.y, rb.velocity.z);
        if (rb.velocity.z <= 0) rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, 0);

        // if the frog is on the ground and moving it adds the hop to the movement
        if (isGrounded)
        {
            if (input.x != isMoving.x || input.z != isMoving.z)
            {
                if(hopTimer <= 0)
                {
                    rb.velocity += new Vector3(0, 6f, 0);
                    isGrounded = false;
                    anim.ResetTrigger("isGrounded");
                    anim.SetTrigger("isHopping");
                    hopTimer = 60;
                }
                
                //Debug.Log(input.z);
            }
            
            hasJumped = false;
            //anim.ResetTrigger("isHopping");
            //anim.ResetTrigger("isJumping");
            anim.SetBool("hasHitTheGround", true);
            anim.SetTrigger("isGrounded");
        }

        hopTimer--;
        if (hopTimer <= 0) hopTimer = 0;

        // acts when the frog jumps, if the frog has jumpjuice left. 
        if(playerController.OnJump(true) && jumpJuice > 0)
        {
            isGrounded = false;
            isJumping = true;
            
            if(hasJumped == false)
            {
                anim.SetBool("hasHitTheGround", false);
                anim.SetTrigger("isJumping");
                anim.ResetTrigger("isGrounded");
                hasJumped = true;
            }
            
            rb.velocity += jump * Time.deltaTime * mult;
            jumpJuice--;            
        }

       Physics.gravity = new Vector3(0, -20f, 0); // gravity      
    }

    // triggered when a gameobject collides with the frog
    private void OnCollisionEnter(Collision collision)
    { // checks if the collision object matches the floor layer, sets isGrounded to true and resets jumpJuice if they match
        if (checkDigit(layersToInteractWith.value, collision.collider.gameObject.layer))
        {
            isGrounded = true;
            isJumping = false;
            jumpJuice = 25;
        }            
    }

    int setDigit(int bitfield, int n)
    {
        return (1 << n) | bitfield;
    }

    bool checkDigit(int bitfield, int n)
    {
        return ((bitfield >> n) & 1) == 1;
    }
}
