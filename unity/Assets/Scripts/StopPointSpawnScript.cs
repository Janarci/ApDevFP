using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class StopPointSpawnScript : MonoBehaviour
{
    [SerializeField] private GameObject Blockings;
    [SerializeField] private Collider Player;

    [SerializeField] private PathingScript pathingManager;

    [SerializeField] private ShopUIBehavior ShopManager;
    [SerializeField] private CampUIBehavior CampManager;
    [SerializeField] private GameObject spawnHandler;
    [SerializeField] private CoinHandler coinHandler;
    

    private bool triggerOnce = false;

    private bool spawnUIonce = false;

    private float BLOCKED_TIME = 30.0f;
    private float MINI_TIME = 22.0f;
    private float BOSS_TIME = 75.0f;

    private float SPAWN_TIMER = 0.0f;

    private void OnTriggerEnter(Collider other)
    {
        if (other == Player)
        {
            if (!triggerOnce)
            {
                pathingManager.playerStop = true;
                Debug.Log("startSpawn1");
                triggerOnce = true;
                SPAWN_TIMER = 0.0f;
                //START SPAWN MOBS HERE
                if (pathingManager.pathTypeList[pathingManager.currentLocation] != PathingScript.pathType.SHOP 
                    && pathingManager.pathTypeList[pathingManager.currentLocation] != PathingScript.pathType.CAMP)
                {
                    FindObjectOfType<BGMhandler>().setCurrentSound("Blocked");
                    spawnHandler.SetActive(true);
                }
                if (pathingManager.pathTypeList[pathingManager.currentLocation] == PathingScript.pathType.BOSS)
                {
                    FindObjectOfType<BGMhandler>().setCurrentSound("Boss");
                }
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (triggerOnce)
        {
            SPAWN_TIMER += Time.deltaTime;
            //Debug.Log(SPAWN_TIMER);
            if (pathingManager.pathTypeList[pathingManager.currentLocation] == PathingScript.pathType.BLOCKED)
            {
                if (SPAWN_TIMER >= BLOCKED_TIME)
                {
                    pathingManager.playerStop = false;
                    Destroy(Blockings);
                    Destroy(spawnHandler);
                    coinHandler.getPathCompleteCoin(530);
                    triggerOnce = false;
                    Destroy(this);
                    FindObjectOfType<BGMhandler>().setCurrentSound("Idle");

                }
            }
            else if (pathingManager.pathTypeList[pathingManager.currentLocation] == PathingScript.pathType.MINI)
            {
                if (SPAWN_TIMER >= MINI_TIME)
                {
                    pathingManager.playerStop = false;
                    Destroy(Blockings);
                    Destroy(spawnHandler);
                    coinHandler.getPathCompleteCoin(350);
                    triggerOnce = false;
                    Destroy(this);
                    FindObjectOfType<BGMhandler>().setCurrentSound("Idle");

                }
            }
            else if (pathingManager.pathTypeList[pathingManager.currentLocation] == PathingScript.pathType.BOSS)
            {
                if (SPAWN_TIMER >= BOSS_TIME)
                {
                    pathingManager.playerStop = false;
                    Destroy(Blockings);
                    Destroy(spawnHandler);
                    triggerOnce = false;
                    Destroy(this);
                    FindObjectOfType<BGMhandler>().setCurrentSound("Idle");
                    SceneManager.LoadSceneAsync("Win");
                }
            }
            else if (pathingManager.pathTypeList[pathingManager.currentLocation] == PathingScript.pathType.SHOP)
            {
                if (!spawnUIonce)
                {
                    FindObjectOfType<AdsManager>().ShowRewardedAd();
                    ShopManager.ExitShopClicked();
                    spawnUIonce = true;
                    triggerOnce = false;
                    Destroy(this);
                }
            }
            else if (pathingManager.pathTypeList[pathingManager.currentLocation] == PathingScript.pathType.CAMP)
            {
                if (!spawnUIonce)
                {
                    FindObjectOfType<AdsManager>().ShowRewardedAd();
                    CampManager.startResting();
                    spawnUIonce = true;
                    triggerOnce = false;
                    Destroy(this);
                }
            }


        }
    }
}
