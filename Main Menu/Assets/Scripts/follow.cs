using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class follow : MonoBehaviour
{
    public GameObject player;

    private Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        if (player == null) player = GameObject.Find("player");
        offset = transform.position - player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (PowerUpController.isDead == false)
        {
            transform.position = player.transform.position + offset;
        }
    }
}
