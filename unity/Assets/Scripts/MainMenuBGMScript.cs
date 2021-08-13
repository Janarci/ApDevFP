using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuBGMScript : MonoBehaviour
{
    [SerializeField] private BGMhandler bGMhandler;
    void Awake()
    {
        
        bGMhandler.setCurrentSound("Idle");

    }
}
