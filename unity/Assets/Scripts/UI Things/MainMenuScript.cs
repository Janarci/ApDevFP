using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenuScript : MonoBehaviour
{
	public void onStartPress()
	{
		SceneManager.LoadSceneAsync("TestMap");
	}
	public void onExitPress()
	{
		Application.Quit();

	}

}
