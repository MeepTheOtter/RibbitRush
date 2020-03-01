using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnPlayerCollision : MonoBehaviour
{
    public LayerMask player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // destroys the object if it collides with the player
    private void OnCollisionEnter(Collision collision)
    {
        if (checkDigit(player.value, collision.collider.gameObject.layer))
        {
            Destroy(this.gameObject);
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
