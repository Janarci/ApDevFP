using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseMenu : MonoBehaviour
{
	// Start is called before the first frame update
	public void onRestartPress()
	{
		SceneManager.LoadSceneAsync("TestMap");
	}
	public void onMainMenu()
	{
		SceneManager.LoadSceneAsync("MainMenu");
	}
	public void onExitPress()
	{
		Application.Quit();

	}

}
