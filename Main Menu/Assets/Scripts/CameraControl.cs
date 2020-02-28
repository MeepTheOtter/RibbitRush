using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    float rotateY = 0f;
    bool rotateRight = false;
    bool rotateLeft = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            rotateRight = true;
        }
        if (Input.GetKeyDown(KeyCode.A) && rotateY != -90f)
        {
            rotateLeft = true;
        }

        if (rotateRight && rotateY != 90f)
        {
            rotateY += 5f;

            if (rotateY == 90f || rotateY == 0f) rotateRight = false;

            rotateLeft = false;
        }

        if (rotateLeft && rotateY != -90f)
        {
            rotateY -= 5f;

            if (rotateY == -90f || rotateY == 0f) rotateLeft = false;

            rotateRight = false;
        }
        transform.eulerAngles = new Vector3(0f, rotateY, 0f);
    }
}
