using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class TapEventArgs : EventArgs
{
    public Vector2 TapPosition
    {
        get
        {
            return tapPosition;
        }
    }

    private Vector2 tapPosition;

    public GameObject HitObject
    {
        get;
        private set;
    }
    public TapEventArgs(Vector2 pos, GameObject hit = null)
    {
        tapPosition = pos;
        HitObject = hit;
    }
}
