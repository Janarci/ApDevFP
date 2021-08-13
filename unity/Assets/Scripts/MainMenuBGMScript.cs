using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuBGMScript : MonoBehaviour
{
    void Awake()
    {
        GameObject[] music = GameObject.FindGameObjectsWithTag("BGM");
        if(music.Length > 1)
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);
        
    }
}
