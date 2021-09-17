using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.Audio;

public class sfxHandler : MonoBehaviour
{

    public static sfxHandler sfxInstance;

    public Sounds[] sounds;
    private Sounds currentSpellSound;

	public void Awake()
	{

        if (sfxInstance != null && sfxInstance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        sfxInstance = this;
        DontDestroyOnLoad(this);

        foreach (Sounds s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
        }

	}

    public void setCurrentSound(string soundName)
    {
        currentSpellSound = Array.Find(sounds, sound => sound.soundName == soundName);

    }

    public void play()
    {
        currentSpellSound.source.Play();

    }

}
