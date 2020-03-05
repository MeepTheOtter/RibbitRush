using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[ExecuteInEditMode]
public class Whirlpool1 : MonoBehaviour
{
    
    public Material material;
    // Start is called before the first frame update
   
    // Update is called once per frame
    void Update()
    {
        if(material != null){
            material.SetVector("_Position", new Vector2(transform.position.x, transform.position.z));
            material.SetVector("_Scale", new Vector2(transform.localScale.x, transform.localScale.y));
        }
        
    }

}
