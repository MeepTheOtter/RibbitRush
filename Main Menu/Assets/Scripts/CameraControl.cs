using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CameraControl : MonoBehaviour
{
    float rotateY = 0f;

    public Button HTPButton;
    public Button HTPBackButton;
    public Button ShopButton;
    public Button ShopBackButton;
    public Button QuitButton;

    bool rotateRight = false;
    bool rotateLeft = false;
    bool HTPClicked = false;
    bool ShopClicked = false;
    bool HTPBackClicked = false;
    bool ShopBackClicked = false;
    bool QuitClicked = false;

    // Start is called before the first frame update
    void Start()
    {
        HTPButton.onClick.AddListener(() =>
        {
            HTPClicked = true;
        });
        ShopButton.onClick.AddListener(() =>
        {
            ShopClicked = true;
        });
        HTPBackButton.onClick.AddListener(() =>
        {
            HTPBackClicked = true;
        });
        ShopBackButton.onClick.AddListener(() =>
        {
            ShopBackClicked = true;
        });
        QuitButton.onClick.AddListener(() =>
        {
            QuitClicked = true;
        });
    }

    // Update is called once per frame
    void Update()
    {
        if (HTPClicked) { rotateLeft = true; }
        if (HTPBackClicked) { rotateRight = true; }
        if (ShopClicked) { rotateRight = true; }
        if (ShopBackClicked) { rotateLeft = true; }
        if (QuitClicked) { Application.Quit(); }

        if (rotateRight && rotateY != 90f)
        {
            rotateY += 5f;

            if (rotateY == 90f || rotateY == 0f)
            {
                rotateRight = false;
                ShopClicked = false;
                HTPBackClicked = false;
            }
            rotateLeft = false;
        }

        if (rotateLeft && rotateY != -90f)
        {
            rotateY -= 5f;
            if (rotateY == -90f || rotateY == 0f)
            {
                rotateLeft = false;
                ShopBackClicked = false;
                HTPClicked = false;
            }
            rotateRight = false;
        }
        transform.eulerAngles = new Vector3(0f, rotateY, 0f);
    }
}
