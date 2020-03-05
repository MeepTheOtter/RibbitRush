using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorSwitcher : MonoBehaviour
{
    public Button GreenButton;
    public Button RedButton;
    public Button YellowButton;
    public Button BlueButton;
    public Button PurpleButton;
    public Button BlackButton;

    public static int C = 0;

    Material material;
    void Start()
    {
        GreenButton.onClick.AddListener(() =>
        {
            C = 0;
        });
        RedButton.onClick.AddListener(() =>
        {
            C = 1;
        });
        YellowButton.onClick.AddListener(() =>
        {
            C = 2;
        });
        BlueButton.onClick.AddListener(() =>
        {
            C = 3;
        });
        PurpleButton.onClick.AddListener(() =>
        {
            C = 4;
        });
        BlackButton.onClick.AddListener(() =>
        {
            C = 5;
        });
    }
    // Update is called once per frame
    void Update()
    {
        if (C == 0)
        {
            material = Resources.Load<Material>("Material/FrogColorGreen");
            Renderer rend = GetComponent<Renderer>();
            rend.material = material;
        }
        if (C == 1)
        {
            material = Resources.Load<Material>("Material/FrogColorRed");
            Renderer rend = GetComponent<Renderer>();
            rend.material = material;
        }
        if (C == 2)
        {
            material = Resources.Load<Material>("Material/FrogColorGold");
            Renderer rend = GetComponent<Renderer>();
            rend.material = material;
        }
        if (C == 3)
        {
            material = Resources.Load<Material>("Material/FrogColorBlue");
            Renderer rend = GetComponent<Renderer>();
            rend.material = material;
        }
        if (C == 4)
        {
            material = Resources.Load<Material>("Material/FrogColorPurple");
            Renderer rend = GetComponent<Renderer>();
            rend.material = material;
        }
        if (C == 5)
        {
            material = Resources.Load<Material>("Material/FrogColorBlack");
            Renderer rend = GetComponent<Renderer>();
            rend.material = material;
        }
    }
}
