﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager {

    public class InputConfig
    {
        public KeyCode jump;
        public string axis1x;
        public string axis1y;
        public bool invertY1 = false;

        public InputConfig()
        {
			jump = KeyCode.Space;
            axis1x = "Horizontal";
            axis1y = "Vertical";
        }

        public bool OnJump(bool fireWhileHolding = false)
        {
            return fireWhileHolding ? Input.GetKey(jump) : Input.GetKeyDown(jump);
        }
        private float GetAxis(string axis, bool raw = false)
        {
            float val = 0;
            try
            {
                val = raw ? Input.GetAxisRaw(axis) : Input.GetAxis(axis);
            }
            catch { }
            return val;
        }
        public float GetAxis1x(bool raw = false)
        {
            return GetAxis(axis1x, raw);
        }
        public float GetAxis1y(bool raw = false)
        {
            float val = GetAxis(axis1y, raw);
            if (invertY1) val *= -1;
            return val;
        }
        public Vector3 GetAxis1(bool raw = false)
        {
            return new Vector3(GetAxis1x(raw), 0, GetAxis1y(raw));
        }
    }

    static public InputConfig player1 = new InputConfig();
    static public InputConfig player2 = new InputConfig();


    static public bool SetButton(ref KeyCode mapping)
    {
        KeyCode original = mapping; // make a copy of original
        mapping = DetectJoystickButton();
        if (mapping == KeyCode.None)
        {
            mapping = original; // reset to original value
            return false; // waiting...
        }
        return true; // success
    }

    static KeyCode DetectJoystickButton()
    {
        // keycodes for ALL joystick buttons: 350 - 509
        int minCode = 350;
        int maxCode = 509;

        for (int i = minCode; i <= maxCode; i++) // 8 joysticks, 20 different buttons each
        {
            KeyCode code = (KeyCode)i;
            if (Input.GetKeyDown(code)) return code;
        }
        return KeyCode.None;
    }
}
