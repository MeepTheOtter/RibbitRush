using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogMovement : MonoBehaviour
{

    Vector3 velocity = new Vector3(0, 0, .02f);
    GameObject Target;
    
    // Start is called before the first frame update
    void Start()
    {
        Target = GameObject.Find("MakerTarget");
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += velocity;
        if (Target.transform.position.y <= transform.position.y - 5)
        {
            Destroy(gameObject);
        }
    }
}
