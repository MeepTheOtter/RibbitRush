using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogMovement : MonoBehaviour
{

    Vector3 velocity = new Vector3(0, 0, .02f);
    Vector3 velocity2 = new Vector3(.02f, 0, .02f);
    Vector3 velocity3 = new Vector3(-.02f, 0, .02f);
    int Thing2 = 1;
    int Thing = 1;
    GameObject Target;
    
    // Start is called before the first frame update
    void Start()
    {
        Target = GameObject.Find("MakerTarget");
    }

    // Update is called once per frame
    void Update()
    {
        if (Thing == 1) transform.position += velocity;
        if (Thing == 2) transform.position += velocity2;
        if (Thing == 3) transform.position += velocity3;
        if (Target.transform.position.y <= transform.position.y - 5)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PushBlocks>() != null)
        {
            float Val = Random.Range(0.0f, 100f);
            if (Val < 50) Thing = 2;
            if (Val > 50) Thing = 3;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<PushBlocks>() != null) Thing = 1;
    }
}
