﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    public void DoJump()
    {
        Input.GetKeyDown(KeyCode.Space);
    }
}
