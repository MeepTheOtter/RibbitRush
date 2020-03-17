using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyLog : MonoBehaviour
{

    BoxCollider BC;
    Rigidbody rb;
    GameObject Target;

    // Start is called before the first frame update
    void Start()
    {
        if (gameObject.name == "END")
        {
            BC = gameObject.AddComponent<BoxCollider>();
            Vector3 S = BC.transform.localScale;
            S.x += 5;
            BC.transform.localScale = S;
            rb = gameObject.AddComponent<Rigidbody>();
            BC.isTrigger = true;
            rb.isKinematic = true;
        }
        Target = GameObject.Find("MakerTarget");
    }

    // Update is called once per frame
    void Update()
    {
        if (Target.transform.position.y <= transform.position.y - 5)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<LogMovement>() != null) Destroy(other.gameObject);
    }
}
