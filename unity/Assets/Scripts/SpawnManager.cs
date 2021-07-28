using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    private int stage = 1;
    [SerializeField] private GameObject fairyTemplate1;
    [SerializeField] private GameObject fairyTemplate2;
    [SerializeField] private GameObject fairyTemplate3;
    private float SPAWN_INTERVAL = 3.0f;
    private float INIT_TIME = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        this.fairyTemplate1.SetActive(false);
        this.fairyTemplate2.SetActive(false);
        this.fairyTemplate3.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        INIT_TIME += Time.deltaTime;

        if (stage == 1)
        {
            SPAWN_INTERVAL = 6.0f;
        }
        if (stage == 2)
        {
            SPAWN_INTERVAL = 3.5f;
        }
        if (stage == 3)
        {
            SPAWN_INTERVAL = 1.5f;
        }

        if (INIT_TIME >= SPAWN_INTERVAL)
        {
            INIT_TIME = 0.0f;
            spawnFairy();
        }
    }

    private void spawnFairy()
    {
        int fairyType = Random.Range(1, 4);

        float xOffset = Random.Range(-3.0f, 3.0f);
        //float yOffset = Random.Range(1, 3);
        //float zOffset = Random.Range(1, 3);
        Vector3 spawnPosition = this.transform.localPosition;
        spawnPosition.x = this.transform.localPosition.x + xOffset;
        GameObject fairyClone;
        if (fairyType == 1)
        {

            fairyClone = GameObject.Instantiate(this.fairyTemplate1, spawnPosition, this.fairyTemplate1.transform.rotation, this.transform);
            fairyClone.SetActive(true);
        }
        else if (fairyType == 2)
        {

            fairyClone = GameObject.Instantiate(this.fairyTemplate2, spawnPosition, this.fairyTemplate2.transform.rotation, this.transform);
            fairyClone.SetActive(true);
        }
        else if (fairyType == 3)
        {

            fairyClone = GameObject.Instantiate(this.fairyTemplate3, spawnPosition, this.fairyTemplate3.transform.rotation, this.transform);
            fairyClone.SetActive(true);
        }
        
    }

}
