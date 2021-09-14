using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoseMenu : MonoBehaviour
{
	public WebHandlerScript webManager;
	public Text playerName;
	public Text playerScore;
	public Text playerMsg;

    // Start is called before the first frame update
    private void Awake()
    {
		playerName.text = webManager.currentPlayerName;
		playerScore.text = "Score Obtained: " + webManager.currentPlayerScore.ToString();

		if (webManager.GetPlayers())
		{
			playerMsg.text = "New Personal Best!";
		}
        else
        {
			playerMsg.text = "You did great! Maybe you could do better?";
		}
	}

    public void onRestartPress()
	{
		SceneManager.LoadSceneAsync("EzMap");
		FindObjectOfType<BGMhandler>().setCurrentSound("Idle");
	}
	public void onMainMenu()
	{
		SceneManager.LoadSceneAsync("MainMenu");
		FindObjectOfType<BGMhandler>().setCurrentSound("Idle");
	}
	public void onExitPress()
	{
		Application.Quit();

	}

}
