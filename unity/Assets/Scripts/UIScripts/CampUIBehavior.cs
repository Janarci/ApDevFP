using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CampUIBehavior : MonoBehaviour
{
    [SerializeField] private GameObject InitUI;
    [SerializeField] private GameObject BlackScreen;
    [SerializeField] private GameObject AfterRest;

    [SerializeField] private GameObject campCollider;
    [SerializeField] private PathingScript Player;

    // Start is called before the first frame update
    void Start()
    {
        resetAllUI();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void resetAllUI()
    {
        InitUI.SetActive(false);
        AfterRest.SetActive(false);
    }

    public void startResting()
    {
        InitUI.SetActive(true);
        BlackScreen.GetComponent<Animator>().Play("Blackscreen");
        //heal all health

        BlackScreen.GetComponent<Animator>().StopPlayback();
        InitUI.SetActive(false);
        AfterRest.SetActive(true);
        //StartCoroutine(RestAnim());
    }

    IEnumerator RestAnim()
    {
        InitUI.SetActive(true);
        //BlackScreen.GetComponent<Animator>().Play("Blackscreen");
        //heal all health
        yield return new WaitForSeconds(2f);
        //BlackScreen.GetComponent<Animator>().StopPlayback();
        InitUI.SetActive(false);
        AfterRest.SetActive(true);

    }

    public void ContinueClicked()
    {
        Destroy(campCollider);
        Player.playerStop = false;
        AfterRest.SetActive(false);
    }
}
