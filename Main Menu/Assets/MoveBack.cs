using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBack : MonoBehaviour
{
    public GameObject Parent;
    void Start()
    {
        transform.position = Parent.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 S = Parent.transform.position;
        S.x -= 2;
        transform.position = S;
    }
}
