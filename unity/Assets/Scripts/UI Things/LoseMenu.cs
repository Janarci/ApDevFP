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

    // Start is called before the first frame update
    private void Awake()
    {
		playerName.text = webManager.currentPlayerName;
		playerScore.text = webManager.currentPlayerScore.ToString();

		webManager.GetPlayers();
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
