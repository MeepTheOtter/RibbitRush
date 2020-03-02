using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnMyShit : MonoBehaviour
{

    public GameObject Lily;
    public GameObject flower;

    // Start is called before the first frame update
    void Start()
    {
        var Name = Instantiate(Lily, Vector3.zero, Quaternion.identity);
        Vector3 s = Name.transform.position;
        s.x += -.8f;
        s.y += .1f;
        var Flower = Instantiate(flower, s, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
