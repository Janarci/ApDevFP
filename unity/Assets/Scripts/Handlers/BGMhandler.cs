using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.Audio;

public class BGMhandler : MonoBehaviour
{

    public static BGMhandler BGM_Instance;

    public Sounds[] BGMs;
    private Sounds currentBGM;

    public void Awake()
    {

        if (BGM_Instance != null && BGM_Instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        BGM_Instance = this;
        DontDestroyOnLoad(this);

        foreach (Sounds s in BGMs)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.playOnAwake = false;
            s.source.loop = true;
        }

        setCurrentSound("Idle");
    }

    public void setCurrentSound(string soundName)
    {
        if (currentBGM != null)
        {
            currentBGM.source.Stop();
        }
        currentBGM = Array.Find(BGMs, sound => sound.soundName == soundName);
        currentBGM.source.Play();
    }


}

