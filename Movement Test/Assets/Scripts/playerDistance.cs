using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerDistance : MonoBehaviour
{

    public GameObject player;
    public float distToPlayer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (player == null) player = GameObject.Find("player");
        //distToPlayer = Vector3.Distance(transform.position, player.transform.position);
        //Debug.Log(distToPlayer);
    }

}
