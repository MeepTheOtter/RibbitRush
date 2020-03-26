// Ribbit Rush-
// a script to move the frog around
// Copyright Team Nine 2020

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputMover : MonoBehaviour
{


    InputManager.InputConfig playerController;
    CharacterController Controller;

    private Vector3 input;

    public LayerMask layersToInteractWith;

    public bool isGrounded; // true, frog is on the ground. false, frog is not on the ground
    public bool isJumping; // used to determine if the frog is jumping or not

    // Current Velocity floats
    float X = 0;
    float Y = 0;
    float Z = 0;
    // Gravity constant
    float G = -7;

    void Start()
    {
        Controller = gameObject.GetComponent<CharacterController>();
    }
    void Update()
    {
        // Reduce speed over time
        X *= .50f;
        Z *= .50f;
        if (!PowerUpController.isDead)
        {
            // checks input from the player
            input.x = Input.GetAxis("Horizontal");
            input.z = Input.GetAxis("Vertical");
        } else
        {
            input = Vector3.zero;
        }
        // Calculates speed for different states
        float S = (isJumping) ? 2 : 4;

        // Increases speed when ther is input
        X += S * input.x;
        Z += S * input.z;

        // When not jumping you can jump
        if (!isJumping && Input.GetAxis("Jump") > 0 && !PowerUpController.isDead)
        {
            Y = 7;
            isJumping = true;
        }
        
        // Adding gravity every frame
        Y += G * Time.deltaTime;
        if (X >= 4) X = 4;
        if (X <= -4) X = -4;
        if (Z >= 4) Z = 4;
        if (Z <= -4) Z = -4;

        // Move the object
        Controller.Move(new Vector3( X, Y, Z ) * Time.deltaTime);
    }

    // triggered when a gameobject collides with the frog
    void OnCollisionEnter(Collision collision)
    {
        // set it back to grounded
        isJumping = false;
    }
    private void OnTriggerEnter(Collider other)
    {
        // set it back to grounded
        isJumping = false;
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
