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

	private bool once = false;

    // Start is called before the first frame update
    void Update()
    {
		playerName.text = FindObjectOfType<WebHandlerScript>().currentPlayerName;
		playerScore.text = "Score Obtained: " + FindObjectOfType<WebHandlerScript>().currentPlayerScore.ToString();
		FindObjectOfType<WebHandlerScript>().isOnAfterGameMenu = true;
		once = true;
		Debug.Log("WorkinAwake");
		
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
		playerName.text = FindObjectOfType<WebHandlerScript>().currentPlayerName;
		playerScore.text = "Score Obtained: " + FindObjectOfType<WebHandlerScript>().currentPlayerScore.ToString();
		FindObjectOfType<WebHandlerScript>().isOnAfterGameMenu = true;
		once = true;
		Application.Quit();
		Debug.Log("WorkinButon");
	}

}
