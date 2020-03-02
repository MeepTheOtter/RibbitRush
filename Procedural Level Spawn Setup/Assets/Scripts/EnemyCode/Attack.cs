using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{

    GameObject Player;
    Rigidbody rb;

    float counter = 500;

    float Distance = 0;

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Player");
        rb = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Distance = calcDistance();
        if (Distance < 4 && counter > 500) Attak();
        counter += 1f * Time.deltaTime;
    }

    float calcDistance()
    {
        Vector3 P = Player.transform.position;
        Vector3 E = gameObject.transform.position;
        return Mathf.Sqrt(Mathf.Pow(P.x - E.x, 2) + Mathf.Pow(P.y - E.y, 2) + Mathf.Pow(P.z - E.z, 2));
    }

    void Attak()
    {
        Vector3 S = (Player.transform.position - transform.position) * 200;
        rb.velocity += S * Time.deltaTime;
        counter = 0;
    }
}
