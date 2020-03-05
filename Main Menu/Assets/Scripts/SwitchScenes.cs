using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SwitchScenes : MonoBehaviour
{
    public Button IncreaseButton;
    public int SceneIndex = 0;
    private bool runTimer = false;
    private float timer = 40f;

    private void SceneLoader()
    {
        SceneManager.LoadScene(SceneIndex);
        timer = 40f;
    }

    private void Start()
    {
        {
            IncreaseButton.onClick.AddListener(() =>
            {
                runTimer = true;
                if (SceneIndex < 2)
                {
                    SceneIndex = SceneIndex + 1;
                }
                else
                {
                    SceneIndex = 0;
                }
            });


        }
    }

    private void Update()
    {
        if (runTimer)
        {
            timer--;

            if (timer <= 0)
            {
                timer = 0;
                runTimer = false;
                SceneLoader();
            }
        }
    }
}
