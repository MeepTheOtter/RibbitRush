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

    Material material;
    void Start()
    {
        GreenButton.onClick.AddListener(() =>
        {
            material = Resources.Load<Material>("Material/FrogColorGreen");
            Renderer rend = GetComponent<Renderer>();
            rend.material = material;
        });
        RedButton.onClick.AddListener(() =>
        {
            material = Resources.Load<Material>("Material/FrogColorRed");
            Renderer rend = GetComponent<Renderer>();
            rend.material = material;
        });
        YellowButton.onClick.AddListener(() =>
        {
            material = Resources.Load<Material>("Material/FrogColorYellow");
            Renderer rend = GetComponent<Renderer>();
            rend.material = material;
        });
        BlueButton.onClick.AddListener(() =>
        {
            material = Resources.Load<Material>("Material/FrogColorBlue");
            Renderer rend = GetComponent<Renderer>();
            rend.material = material;
        });
        PurpleButton.onClick.AddListener(() =>
        {
            material = Resources.Load<Material>("Material/FrogColorPurple");
            Renderer rend = GetComponent<Renderer>();
            rend.material = material;
        });
        BlackButton.onClick.AddListener(() =>
        {
            material = Resources.Load<Material>("Material/FrogColorBlack");
            Renderer rend = GetComponent<Renderer>();
            rend.material = material;
        });
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
