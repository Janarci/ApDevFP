using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenuScript : MonoBehaviour
{
	private string sceneName;
	public void onEzPress()
	{
		SceneManager.LoadSceneAsync("EzMap");
	}
	public void onMidPress()
	{
		SceneManager.LoadSceneAsync("AverageMap");
	}
	public void onHardPress()
	{
		SceneManager.LoadSceneAsync("HardMap");
	}
	public void MidMapToggle(bool value)
	{
		if (value)
		{
			sceneName = "EzMap";
		}

	}
	public void HardMapToggle(bool value)
	{
		if (value)
		{
			sceneName = "AverageMap";
		}

	}
	public void ezMapToggle(bool value)
	{
		if (value)
		{
			sceneName = "HardMap";
		}

	}
	public void newScene()
	{
		SceneManager.LoadSceneAsync("New Scene");

	}
	public void onExitPress()
	{
		Application.Quit();

	}

}
