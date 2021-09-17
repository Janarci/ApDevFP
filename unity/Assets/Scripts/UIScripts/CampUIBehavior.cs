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

    [SerializeField] private HealthHandler healthHandler;

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
        


        StartCoroutine(waitforsecs());
        
        
        
    }

    IEnumerator waitforsecs()
    {
        InitUI.SetActive(true);
        BlackScreen.GetComponent<Animator>().SetTrigger("StartBlackScreen");
        yield return new WaitForSeconds(2f);
        healthHandler.fullHeal();
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
