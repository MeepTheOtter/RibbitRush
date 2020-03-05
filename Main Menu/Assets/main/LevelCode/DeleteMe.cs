using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteMe : MonoBehaviour
{
    GameObject Target;

    // Start is called before the first frame update
    void Start()
    {
        Target = GameObject.Find("MakerTarget");
    }

    // Update is called once per frame
    void Update()
    {
        //if (Target.transform.position.y <= transform.position.y - 5)
        //{
          //  Destroy(gameObject);
        //}
    }
}
