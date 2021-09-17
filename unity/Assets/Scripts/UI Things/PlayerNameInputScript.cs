using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerNameInputScript : MonoBehaviour
{
    public WebHandlerScript webManager;
    public Text playerNameInput;
    public void onInputChange()
    {
        webManager.currentPlayerName = playerNameInput.text;
    }
    public void onInputDone()
    {
        webManager.currentPlayerName = playerNameInput.text;
    }

}
