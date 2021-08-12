using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenuScript : MonoBehaviour
{
	public void onStartPress()
	{
		SceneManager.LoadSceneAsync("New Scene");
	}
	public void onExitPress()
	{
		Application.Quit();

	}

}
