using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    private GameObject fairyTemplate1;
    private GameObject fairyTemplate2;
    private GameObject fairyTemplate3;
    private Material fairymat1;
    private Material fairymat2;
    private Material fairymat3;
    private float SPAWN_INTERVAL = 3.0f;
    private float INIT_TIME = 10.0f;

    public bool isBossSpawner = false;
    public float BOSS_INTERVAL1 = 20.0f;

    public AssetBundleManager assetManager;
    //public bool roundStart = false;
    private void Awake()
    {
        assetManager = GameObject.Find("AssetManager").GetComponent<AssetBundleManager>();
        AssetBundle test = assetManager.LoadBundle("mobs");

    }
    // Start is called before the first frame update
    void Start()
    {
        fairymat1 = Resources.Load<Material>("HuaYao_01 1");
        fairymat2 = Resources.Load<Material>("HuaYao_02 1");
        fairymat3 = Resources.Load<Material>("HuaYao_03 1");
        if (isBossSpawner)
        {
            fairyTemplate1 = assetManager.GetAsset<GameObject>("mobs", "DragonBoss");
            fairyTemplate2 = assetManager.GetAsset<GameObject>("mobs", "DragonBoss2");
            fairyTemplate3 = assetManager.GetAsset<GameObject>("mobs", "DragonBoss3");
        }
        else
        {
            fairyTemplate1 = assetManager.GetAsset<GameObject>("mobs", "Fairy1");
            fairyTemplate2 = assetManager.GetAsset<GameObject>("mobs", "Fairy2");
            fairyTemplate3 = assetManager.GetAsset<GameObject>("mobs", "Fairy3");

        }
    }

    // Update is called once per frame
    void Update()
    {
        //if (roundStart)
        //{
        INIT_TIME += Time.deltaTime;

            if (FindObjectOfType<LevelHandler>().level == 1)
            {
                SPAWN_INTERVAL = 16.0f;
                BOSS_INTERVAL1 = 20.0f;
            }
            else if (FindObjectOfType<LevelHandler>().level == 2)
            {
                SPAWN_INTERVAL = 14.0f;
                BOSS_INTERVAL1 = 18.5f;
            }
            else if (FindObjectOfType<LevelHandler>().level == 3)
            {
                SPAWN_INTERVAL = 9.5f;
                BOSS_INTERVAL1 = 15.0f;
            }

        if (isBossSpawner)
        {
            if (INIT_TIME >= BOSS_INTERVAL1)
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
            fairyClone.GetComponentInChildren<Renderer>().material = fairymat1;
            fairyClone.SetActive(true);
        }
        else if (fairyType == 2)
        {

            fairyClone = GameObject.Instantiate(this.fairyTemplate2, spawnPosition, this.fairyTemplate2.transform.rotation, this.transform);
            fairyClone.GetComponentInChildren<Renderer>().material = fairymat2;
            fairyClone.SetActive(true);
        }
        else if (fairyType == 3)
        {

            fairyClone = GameObject.Instantiate(this.fairyTemplate3, spawnPosition, this.fairyTemplate3.transform.rotation, this.transform);
            fairyClone.GetComponentInChildren<Renderer>().material = fairymat3;
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
