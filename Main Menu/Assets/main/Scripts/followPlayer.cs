using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followPlayer : MonoBehaviour
{
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (player == null) player = GameObject.Find("Cube.016");
        //transform.position = player.transform.position + new Vector3(-3,0,3);
        transform.position = player.transform.position;
    }
}
