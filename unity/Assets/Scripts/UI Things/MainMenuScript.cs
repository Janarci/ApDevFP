using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenuScript : MonoBehaviour
{
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
	public void onExitPress()
	{
		Application.Quit();

	}

}
