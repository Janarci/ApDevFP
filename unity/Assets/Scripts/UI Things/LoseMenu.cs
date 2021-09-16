using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoseMenu : MonoBehaviour
{
	public Text playerName;
	public Text playerScore;
	public Text playerMsg;
	private float INIT_TIME = 0;

    private void Update()
    {
		INIT_TIME += Time.deltaTime;
		playerName.text = FindObjectOfType<WebHandlerScript>().currentPlayerName;
		playerScore.text = "Score Obtained: " + FindObjectOfType<WebHandlerScript>().currentPlayerScore.ToString();

		
		if (FindObjectOfType<LevelHandler>().levelWin == true)
        {
			if (INIT_TIME <= 5.0f)
			{
				if (FindObjectOfType<LevelHandler>().level == 1)
				{
					playerMsg.text = "Average Level Unlocked!";
				}
				else if (FindObjectOfType<LevelHandler>().level == 2)
				{
					playerMsg.text = "Hard Level Unlocked!";
				}
			}
			else
			{
				playerMsg.text = "Congratulations!";
			}
		}
        else
        {
			playerMsg.text = "Better Luck Next Time!";
		}

		if (INIT_TIME > 10.0f)
        {
			INIT_TIME = 0;
        }
	}

    public void onRestartPress()
	{
		AssetBundle.UnloadAllAssetBundles(true);
		if (FindObjectOfType<LevelHandler>().level == 1)
		{
			SceneManager.LoadSceneAsync("EzMap");
		}
		else if (FindObjectOfType<LevelHandler>().level == 2)
		{
			SceneManager.LoadSceneAsync("MidMap");
		}
		else if (FindObjectOfType<LevelHandler>().level == 3)
		{
			SceneManager.LoadSceneAsync("HardMap");
		}
		FindObjectOfType<BGMhandler>().setCurrentSound("Idle");
	}
	public void onMainMenu()
	{
		AssetBundle.UnloadAllAssetBundles(true);
		SceneManager.LoadSceneAsync("MainMenu");
		FindObjectOfType<BGMhandler>().setCurrentSound("Idle");
	}
	public void onLeaderBoardPress()
	{
		playerName.text = FindObjectOfType<WebHandlerScript>().currentPlayerName;
		playerScore.text = "Score Obtained: " + FindObjectOfType<WebHandlerScript>().currentPlayerScore.ToString();
		FindObjectOfType<WebHandlerScript>().isOnAfterGameMenu = true;
		Application.Quit();
		Debug.Log("WorkinButon");
	}

}
