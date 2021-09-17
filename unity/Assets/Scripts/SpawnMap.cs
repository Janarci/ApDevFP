using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnMap : MonoBehaviour
{

    public AssetBundleManager assetManager;
    private GameObject map;

   [SerializeField] public enum pathType { NORMAL1, NORMAL2, BLOCKED, SHOP, CAMP, MINI1, MINI2, BOSS };

    public pathType PathType;
    private void Awake()
	{
        assetManager = GameObject.Find("AssetManager").GetComponent<AssetBundleManager>();
       // map = assetManager.GetAsset<GameObject>("paths", "AllPathsforEasyLevel");
        //GameObject.Instantiate(map);

       
    }
    // Start is called before the first frame update
    void Start()
    {
        if (PathType == pathType.NORMAL1)
        {
            GameObject stuff = assetManager.GetAsset<GameObject>("paths", "NormalPath1Assets"); ;
            GameObject.Instantiate(stuff, this.transform);

        }
        else if (PathType == pathType.NORMAL2)
        {
            GameObject stuff = assetManager.GetAsset<GameObject>("paths", "NormalPath2Assets"); ;
            GameObject.Instantiate(stuff, this.transform);
        }
        else if(PathType == pathType.BLOCKED)
        {
            GameObject stuff = assetManager.GetAsset<GameObject>("paths", "BlockedPathAssets"); ;
            GameObject.Instantiate(stuff, this.transform);
        }
        else if (PathType == pathType.MINI1)
        {
            GameObject stuff = assetManager.GetAsset<GameObject>("paths", "MiniPath1Assets"); ;
            GameObject.Instantiate(stuff, this.transform);
        }
        else if(PathType == pathType.MINI2)
        {
            GameObject stuff = assetManager.GetAsset<GameObject>("paths", "MiniPath2Assets"); ;
            GameObject.Instantiate(stuff, this.transform);
        }
        else if(PathType == pathType.SHOP)
        {
            GameObject stuff = assetManager.GetAsset<GameObject>("paths", "ShopPathAssets"); ;
            GameObject.Instantiate(stuff, this.transform);
        }
        else if(PathType == pathType.CAMP)
        {
            GameObject stuff = assetManager.GetAsset<GameObject>("paths", "CampPathAssets"); ;
            GameObject.Instantiate(stuff, this.transform);
        }
        else if(PathType == pathType.BOSS)
        {
            GameObject stuff = assetManager.GetAsset<GameObject>("paths", "BossPathAssets"); ;
            GameObject.Instantiate(stuff, this.transform);
        }
    }

}
