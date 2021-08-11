using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;


[System.Serializable]
public class Sounds
{

	public string soundName;
	public AudioClip clip;

	public float volume;
	public float pitch;


	[HideInInspector]
	public AudioSource source;



}
