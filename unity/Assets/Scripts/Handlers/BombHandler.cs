using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BombHandler : MonoBehaviour
{
    public bool bombAvailable = false;
    [SerializeField] private Text BombDisplay;

    public void onBombPurchase()
    {
        bombAvailable = true;
        BombDisplay.text = "1";
    }

    public void onBombUse()
    {
        bombAvailable = false;
        BombDisplay.text = "0";
    }
}
