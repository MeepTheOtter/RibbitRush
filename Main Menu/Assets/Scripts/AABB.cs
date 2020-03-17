using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AABB : MonoBehaviour
{
    public Vector3 halfSize;
    public Vector3 min = Vector3.zero;
    public Vector3 max = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        calcEdges();
    }

    public void calcEdges()
    {
        min = transform.position - halfSize;
        max = transform.position + halfSize;

    }

    public bool checkOverlap(GameObject other)
    {
        AABB otherAABB = other.GetComponent<AABB>();
        if (min.x >= otherAABB.max.x) return false;
        if (max.x <= otherAABB.min.x) return false;

        if (min.y >= otherAABB.max.y) return false;
        if (max.y <= otherAABB.min.y) return false;

        if (min.z >= otherAABB.max.z) return false;
        if (max.z <= otherAABB.min.z) return false;

       else return true;
    }

    private void OnCollisionEnter(Collision collision)
    {
        
    }
}
