using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BombHandler : MonoBehaviour
{
    public bool bombAvailable = false;
    [SerializeField] private Text BombDisplay;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

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
