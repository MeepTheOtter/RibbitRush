using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogMovement : MonoBehaviour
{

    Vector3 velocity = new Vector3(0, 0, 3f);
    Vector3 velocity2 = new Vector3(6f, 0, 3f);
    Vector3 velocity3 = new Vector3(-6f, 0, 3f);
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
        if (Thing == 1) transform.position += velocity * Time.deltaTime;
        if (Thing == 2) transform.position += velocity2 * Time.deltaTime;
        if (Thing == 3) transform.position += velocity3 * Time.deltaTime;
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
