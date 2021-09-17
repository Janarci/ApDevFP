using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class MainMenuScript : MonoBehaviour
{
	private string sceneName = "EzMap";
	[SerializeField] private LevelHandler unlockLevels;
	[SerializeField] private Button midButton;
	[SerializeField] private Button hardButton;



	private void Update()
	{
		if (unlockLevels.EzDone())
		{
			midButton.interactable = true;
		}
		else
		{
			midButton.interactable = false;
		}
		if (unlockLevels.MidDone())
		{
			hardButton.interactable = true;
		}
		else
		{
			hardButton.interactable = false;
		}

	}
	public void onEzPress()
	{
		unlockLevels.level = 1;
		unlockLevels.isCheating = false;
		SceneManager.LoadSceneAsync("EzMap");
	}
	public void onMidPress()
	{
		unlockLevels.level = 2;
		unlockLevels.isCheating = false;
		SceneManager.LoadSceneAsync("AverageMap");
	}
	public void onHardPress()
	{
		unlockLevels.level = 3;
		unlockLevels.isCheating = false;
		SceneManager.LoadSceneAsync("HardMap");
	}
	public void MidMapToggle(bool value)
	{
		if (value)
		{
			sceneName = "AverageMap";
		}

	}
	public void HardMapToggle(bool value)
	{
		if (value)
		{
			sceneName = "HardMap";
		}

	}
	public void ezMapToggle(bool value)
	{
		if (value)
		{
			sceneName = "EzMap";
		}

	}
	public void newScene()
	{
		unlockLevels.isCheating = true;
		SceneManager.LoadSceneAsync(sceneName);

	}
	public void onExitPress()
	{
		Application.Quit();

	}


}
