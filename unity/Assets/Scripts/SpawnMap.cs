using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnMap : MonoBehaviour
{

    public AssetBundleManager assetManager;
    private GameObject map;


    private void Awake()
	{
        assetManager = GameObject.Find("AssetManager").GetComponent<AssetBundleManager>();
        map = assetManager.GetAsset<GameObject>("paths", "AllPathsforEasyLevel");
        GameObject.Instantiate(map);


    }
    // Start is called before the first frame update
    void Start()
    {
    }

}
