using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopPointSpawnScript : MonoBehaviour
{
    [SerializeField] private GameObject Blockings;
    [SerializeField] private Collider Player;

    [SerializeField] private PathingScript pathingManager;

    private bool triggerOnce = false;

    private float BLOCKED_TIME = 45.0f;
    private float MINI_TIME = 25.0f;
    private float BOSS_TIME = 150.0f;

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

                //START SPAWN MOBS HERE
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
            Debug.Log(SPAWN_TIMER);
            if (pathingManager.pathTypeList[pathingManager.currentLocation] == PathingScript.pathType.BLOCKED)
            {
                if (SPAWN_TIMER >= BLOCKED_TIME)
                {
                    pathingManager.playerStop = false;
                    Destroy(Blockings);
                    Destroy(this);
                }
            }
            else if (pathingManager.pathTypeList[pathingManager.currentLocation] == PathingScript.pathType.MINI)
            {
                if (SPAWN_TIMER >= MINI_TIME)
                {
                    pathingManager.playerStop = false;
                    Destroy(Blockings);
                    Destroy(this);
                }
            }
            else if (pathingManager.pathTypeList[pathingManager.currentLocation] == PathingScript.pathType.BOSS)
            {
                if (SPAWN_TIMER >= BOSS_TIME)
                {
                    pathingManager.playerStop = false;
                    Destroy(Blockings);
                    Destroy(this);
                }
            }


        }
    }
}