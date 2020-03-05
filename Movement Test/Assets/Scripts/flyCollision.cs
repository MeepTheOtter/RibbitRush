using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flyCollision : MonoBehaviour
{
    public bool isColliding = false;
    public LayerMask bugLayer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(checkDigit(bugLayer.value, collision.collider.gameObject.layer))
        {
            isColliding = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (checkDigit(bugLayer.value, collision.collider.gameObject.layer))
        {
            //isColliding = false;
        }
    }

    int setDigit(int bitfield, int n)
    {
        return (1 << n) | bitfield;
    }

    bool checkDigit(int bitfield, int n)
    {
        //print(bitfield + n);
        return ((bitfield >> n) & 1) == 1;
    }
}
