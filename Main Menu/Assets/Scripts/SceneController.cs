using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneController : MonoBehaviour {

    bool setupPlayer1Jump = true;
	
	void Update () {
        if (setupPlayer1Jump)
        {
            if(InputManager.SetButton(ref InputManager.player1.jump))
            {
                setupPlayer1Jump = false;
            }
        }
	}
}
