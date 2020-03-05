// Ribbit Rush-
// a script to control the powerups and various frog states, including animation and all interactables
// Copyright Team Nine 2020

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpController : MonoBehaviour
{

    Rigidbody rb;
    flyCollision pd;
    public LayerMask bugLayer;
    public LayerMask flowerLayer;
    public LayerMask snakeLayer;
    public LayerMask waterLayer;
    public float maxScale = .75f;
    public float minScale = .25f;
    public GameObject flyCollider;

    public int iframes = 0;

    //2 == medium, 3 is large, 1 is small and 0 is dead
    public int playerState = 2;
    public bool hasShield = false;
    public bool isDead = false;



    // Start is called before the first frame update
    void Start()
    {
        hasShield = false;
        iframes = 0;
        rb = GetComponent<Rigidbody>();
        pd = GetComponent<flyCollision>();
    }

    // Update is called once per frame
    void Update()
    {
        iframes--;
        if (iframes <= 0) iframes = 0;

        //locks in the scale to never go above the max or below the minimum
        if (transform.localScale.x > maxScale)
        {
            transform.localScale = new Vector3(maxScale, maxScale, maxScale);
        }
        if (transform.localScale.x < minScale)
        {
            isDead = true;
            transform.localScale = new Vector3(minScale, minScale, minScale);
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log(flyCollider.GetComponent<flyCollision>().isColliding);
            if (flyCollider.GetComponent<flyCollision>().isColliding)
            {
                Debug.Log("did it");
                eatFly();
            }
        }
    }

    

    private void OnCollisionEnter(Collision collision)
    {
        //checks collision on the bug layer, increases size of frog. this is where to put animation stuffs and transitions
        if (checkDigit(bugLayer.value, collision.collider.gameObject.layer))
        {
            eatFly();            
        }
        //checks collision on flower layer, turns shield on. shield then needs to interact with the water layer to determine if the frog dies or not.
        if (checkDigit(flowerLayer.value, collision.collider.gameObject.layer) && hasShield == false)
        {
            Debug.Log("made it to flower");
            hasShield = true;
        }
        //checks collision on enemy layer, activates iframes and changes the scale
        if (checkDigit(snakeLayer.value, collision.collider.gameObject.layer) && iframes <= 0)
        {
            Debug.Log("made it to snake");
            iframes = 150;
            playerState--;
            transform.localScale -= new Vector3(.25f, .25f, .25f);
            transform.Translate(1.5f, 0, 0);
        }
        //checks collision on the water layer, if the frog has the shield it gets launched into the air and it loses the shield, otherwise the frog dies and goes to it's death animation
        if (checkDigit(waterLayer.value, collision.collider.gameObject.layer) && iframes <= 40)
        {
            Debug.Log("got wet");
            if(hasShield == true)
            {
                iframes = 150;
                hasShield = false;
                rb.velocity += new Vector3(0, 15f, 0);
            }
            else
            {
                isDead = true;
            }
        }
        //Debug.Log(collision.collider.gameObject.layer);
    }

    private void eatFly()
    {
        Debug.Log("made it to bug");
        playerState++;
        transform.localScale += new Vector3(.25f, .25f, .25f);
        transform.Translate(-1.5f, 0, 0);
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
