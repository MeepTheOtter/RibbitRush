using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputMover : MonoBehaviour {

    LineRenderer line;
    InputManager.InputConfig playerController;
    Rigidbody rb;
    public float speed = 2f;
    public Vector3 gravity = new Vector3(0, 10, 0);
    public Vector3 jump = new Vector3(0, 50, 0);
    //public GameObject floor;
    AABB thisAABB;
    public LayerMask layersToInteractWith;
    public int jumpJuice = 6;
    public float mult;
    public bool isGrounded;
    private Vector3 isMoving = new Vector3(0,0,0);
    public Vector3 hop = new Vector3(0, -5, 0);
    public int maxSpeed = 30;

    void Start () {
        line = GetComponent<LineRenderer>();
        thisAABB = GetComponent<AABB>();
        playerController = InputManager.player1;
        rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {

        Vector3 input = playerController.GetAxis1();
        rb.velocity += input * Time.deltaTime * speed;
        if (rb.velocity.x >= maxSpeed) rb.velocity = new Vector3(maxSpeed, rb.velocity.y, rb.velocity.z);//make changes for negative velocities
        if (rb.velocity.z >= maxSpeed) rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, maxSpeed);


        if (isGrounded)
        {
            if (input.x != isMoving.x || input.z != isMoving.z)
            {
                rb.velocity += new Vector3(0, 4f, 0);
                isGrounded = false;
                //Debug.Log(input.z);
            }
            
        }


        if(playerController.OnJump(true) && jumpJuice > 0)
        {
            rb.velocity += jump * Time.deltaTime * mult;
            jumpJuice--;            
        }
       Physics.gravity = new Vector3(0, -20f, 0);
        

        

        
        
        line.SetPosition(1, input);
        //if (isGrounded) isGrounded = false;
        //print(input);
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (checkDigit(layersToInteractWith.value, collision.collider.gameObject.layer))
        {
            isGrounded = true;
            jumpJuice = 25;
        }
        else
        {
            
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
