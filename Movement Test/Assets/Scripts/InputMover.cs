using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputMover : MonoBehaviour {

    LineRenderer line;
    InputManager.InputConfig playerController;
    public float speed = 2f;
    public Vector3 gravity = new Vector3(0, 10, 0);
    public Vector3 jump = new Vector3(0, 50, 0);
    public GameObject floor;
    AABB thisAABB;
    public int jumpJuice = 6;
    public float mult;

    void Start () {
        line = GetComponent<LineRenderer>();
        thisAABB = GetComponent<AABB>();
        playerController = InputManager.player1;
	}
	
	// Update is called once per frame
	void Update () {

        Vector3 input = playerController.GetAxis1();

        transform.position += input * Time.deltaTime * speed;


        if(playerController.OnJump(true) && jumpJuice > 0)
        {
            transform.position += jump * Time.deltaTime * mult;
            jumpJuice--;
            Physics.gravity = new Vector3(0, -20f, 0);
        }
        Debug.Log(jumpJuice);

        

        
        
        line.SetPosition(1, input);

        //print(input);
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        jumpJuice = 25;
    }
}
