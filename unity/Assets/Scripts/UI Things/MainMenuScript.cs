using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class MainMenuScript : MonoBehaviour
{
	private string sceneName;
	[SerializeField] private LevelHandler unlockLevels;
	[SerializeField] private Button midButton;
	[SerializeField] private Button hardButton;



	private void Update()
	{
		if (unlockLevels.EzDone())
		{
			midButton.gameObject.SetActive(true);
		}
		else
			midButton.gameObject.SetActive(false);

		if (unlockLevels.MidDone())
		{
			hardButton.gameObject.SetActive(true);
		}
		else
			hardButton.gameObject.SetActive(false);


	}
	public void onEzPress()
	{
		unlockLevels.level = 1;
		SceneManager.LoadSceneAsync("EzMap");
	}
	public void onMidPress()
	{
		unlockLevels.level = 2;
		SceneManager.LoadSceneAsync("AverageMap");
	}
	public void onHardPress()
	{
		unlockLevels.level = 3;
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
	public void test()
	{

		unlockLevels.level = 1;
	}

}
