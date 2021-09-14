using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

using UnityEngine.Networking;
using Newtonsoft.Json;
using System.Text;

public class WebHandlerScript : MonoBehaviour
{
    public string currentPlayerName;
    public int currentPlayerScore;

    public static WebHandlerScript webManager = null;
    public int numberRanking = 1;

    private void Awake()
    {
        if (webManager == null)
        {
            webManager = this;
        }
        else if (webManager != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(this);
        
    }

    public string BaseURL
    {
        get { return "https://my-user-scoreboard.herokuapp.com/api/"; }
    }

    public void CreatePlayer()
    {
        StartCoroutine(SamplePostRoutine());
        Debug.Log("Creating Player...");
    }

    public void GetPlayers()
    {
        StartCoroutine(SampleGetPlayersRoutine());
        Debug.Log("Getting Players...");
    }

    public void GetOnePlayer()
    {
        StartCoroutine(SampleGetPlayerRoutine());
        Debug.Log("Getting Player...");
    }

    public void EditPlayer()
    {
        StartCoroutine(SampleEditRoutine());
        Debug.Log("Editing Player...");
    }

    public void DeletePlayer()
    {
        StartCoroutine(SampleDeleteRoutine());
        Debug.Log("Deleted Player...");
    }

    IEnumerator SamplePostRoutine()
    {
        Dictionary<string, string> PlayerParams = new Dictionary<string, string>();
        PlayerParams.Add("group_num", "14");
        PlayerParams.Add("user_name", currentPlayerName);
        PlayerParams.Add("score", currentPlayerScore.ToString());

        string requestString = JsonConvert.SerializeObject(PlayerParams);
        byte[] requestData = new UTF8Encoding().GetBytes(requestString);

        UnityWebRequest request = new UnityWebRequest(BaseURL + "scores", "POST");
        request.SetRequestHeader("Content-Type", "application/json");
        request.uploadHandler = new UploadHandlerRaw(requestData);
        request.downloadHandler = new DownloadHandlerBuffer();

        yield return request.SendWebRequest();

        Debug.Log($"Status Code: {request.responseCode}");
        if (string.IsNullOrEmpty(request.error))
        {
            Debug.Log($"Created Player: {request.downloadHandler.text}");
        }
        else
        {
            Debug.Log($"Error: {request.error}");
        }
    }

    IEnumerator SampleGetPlayersRoutine()
    {
        UnityWebRequest request = new UnityWebRequest(BaseURL + "scores", "GET");
        request.downloadHandler = new DownloadHandlerBuffer();

        yield return request.SendWebRequest();

        Debug.Log($"Status Code: {request.responseCode}");
        if (string.IsNullOrEmpty(request.error))
        {
            Debug.Log($"Got Players: {request.downloadHandler.text}");

            List<Dictionary<string, string>> playerListRaw = JsonConvert.DeserializeObject<
                List<Dictionary<string, string>>>(request.downloadHandler.text);

            numberRanking = 1;
            foreach (Dictionary<string, string> player in playerListRaw)
            {
                Debug.Log($"Player Nickname: {player["user_name"]}");
                if (player["user_name"] == currentPlayerName)
                {
                    if (int.Parse(player["score"]) > currentPlayerScore)
                    {
                        EditPlayer();
                        break;
                    }
                }
                else
                {
                    CreatePlayer();
                }
                numberRanking++;
            }
        }
        else
        {
            Debug.Log($"Error: {request.error}");
        }
    }

    IEnumerator SampleGetPlayerRoutine()
    {
        UnityWebRequest request = new UnityWebRequest(BaseURL + "players/24", "GET");
        request.downloadHandler = new DownloadHandlerBuffer();

        yield return request.SendWebRequest();

        Debug.Log($"Status Code: {request.responseCode}");
        if (string.IsNullOrEmpty(request.error))
        {
            Debug.Log($"Got Player: {request.downloadHandler.text}");

            Dictionary<string, string> playerListRaw = JsonConvert.DeserializeObject<
                Dictionary<string, string>>(request.downloadHandler.text);

            Debug.Log($"Player Nickname: {playerListRaw["nickname"]}");
        }
        else
        {
            Debug.Log($"Error: {request.error}");
        }
    }

    IEnumerator SampleEditRoutine()
    {
        Dictionary<string, string> PlayerParams = new Dictionary<string, string>();
 
        PlayerParams.Add("score", currentPlayerScore.ToString());

        string requestString = JsonConvert.SerializeObject(PlayerParams);
        byte[] requestData = new UTF8Encoding().GetBytes(requestString);

        UnityWebRequest request = new UnityWebRequest(BaseURL + "scores/" + numberRanking.ToString(), "PUT");
        request.SetRequestHeader("Content-Type", "application/json");
        request.uploadHandler = new UploadHandlerRaw(requestData);
        request.downloadHandler = new DownloadHandlerBuffer();

        yield return request.SendWebRequest();

        Debug.Log($"Status Code: {request.responseCode}");
        if (string.IsNullOrEmpty(request.error))
        {
            Debug.Log($"Edited Player: {request.downloadHandler.text}");
        }
        else
        {
            Debug.Log($"Error: {request.error}");
        }
    }

    IEnumerator SampleDeleteRoutine()
    {
        UnityWebRequest request = new UnityWebRequest(BaseURL + "players/20", "DELETE");
        request.downloadHandler = new DownloadHandlerBuffer();

        yield return request.SendWebRequest();

        Debug.Log($"Status Code: {request.responseCode}");
        if (string.IsNullOrEmpty(request.error))
        {
            Debug.Log($"Deleted Player: {request.downloadHandler.text}");
        }
        else
        {
            Debug.Log($"Error: {request.error}");
        }
    }
}
