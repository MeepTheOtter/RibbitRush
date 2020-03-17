using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseGame : MonoBehaviour
{
    public static bool paused = false;
    private void Start()
    {
        paused = false;   
    }

    public void pausedState()
    {
        if(paused == false)
        {
            paused = true;
        }
        else if(paused == true)
        {
            paused = false;
        }
    }
}
