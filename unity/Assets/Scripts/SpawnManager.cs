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
    private float INIT_TIME = 10.0f;

    public bool isBossSpawner = false;
    public float BOSS_INTERVAL1 = 30.0f;

    //public bool roundStart = false;

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
        //if (roundStart)
        //{
            INIT_TIME += Time.deltaTime;

            if (stage == 1)
            {
                SPAWN_INTERVAL = 16.0f;
            }
            if (stage == 2)
            {
                SPAWN_INTERVAL = 2.5f;
            }
            if (stage == 3)
            {
                SPAWN_INTERVAL = 1.5f;
            }

        if (isBossSpawner)
        {
            if (INIT_TIME >= SPAWN_INTERVAL)
            {
                INIT_TIME = Random.Range(0.0f, 3.67f); ;
                spawnDragon();
            }
        }
        else
        {
            if (INIT_TIME >= SPAWN_INTERVAL)
            {
                INIT_TIME = Random.Range(0.0f, 3.6f); ;
                spawnFairy();
            }
        }
        //}
    }

    public void destroyAllFairy()
    {
        int i = 0;

        GameObject[] allFairy = new GameObject[transform.childCount];

        foreach (Transform child in transform)
        {
            allFairy[i] = child.gameObject;
            i += 1;
        }

        foreach (GameObject child in allFairy)
        {
            DestroyImmediate(child.gameObject);

        }

    }

    private void spawnFairy()
    {
        int fairyType = Random.Range(1, 4);

        float xOffset = Random.Range(-3.0f, 3.0f);
        //float yOffset = Random.Range(1, 3);
        //float zOffset = Random.Range(1, 3);
        Vector3 spawnPosition = this.transform.position;
        spawnPosition.x = this.transform.position.x + xOffset;
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

    private void spawnDragon()
    {
        int fairyType = Random.Range(1, 4);

        float xOffset = Random.Range(-3.0f, 3.0f);
        //float yOffset = Random.Range(1, 3);
        //float zOffset = Random.Range(1, 3);
        Vector3 spawnPosition = this.transform.position;
        spawnPosition.x = this.transform.position.x + xOffset;
        GameObject fairyClone;
        if (fairyType == 1)
        {

            fairyClone = GameObject.Instantiate(this.fairyTemplate1, spawnPosition, this.fairyTemplate1.transform.rotation);
            fairyClone.SetActive(true);
        }
        else if (fairyType == 2)
        {

            fairyClone = GameObject.Instantiate(this.fairyTemplate2, spawnPosition, this.fairyTemplate2.transform.rotation);
            fairyClone.SetActive(true);
        }
        else if (fairyType == 3)
        {

            fairyClone = GameObject.Instantiate(this.fairyTemplate3, spawnPosition, this.fairyTemplate3.transform.rotation);
            fairyClone.SetActive(true);
        }

    }
}
