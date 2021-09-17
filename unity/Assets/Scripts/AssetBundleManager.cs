using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class AssetBundleManager : MonoBehaviour
{

    public string BundleRootPath
    {
        get
        {
#if UNITY_EDITOR
            return Application.streamingAssetsPath;
#elif UNITY_ANDROID
            return Application.persistentDataPath;
#endif
        }

    }

    Dictionary<string, AssetBundle> loadedBundles = new Dictionary<string, AssetBundle>();


    public AssetBundle LoadBundle(string bundle_name)
    {
        if (loadedBundles.ContainsKey(bundle_name))
        {
            return loadedBundles[bundle_name];
        }

        AssetBundle ret = AssetBundle.LoadFromFile(Path.Combine(BundleRootPath, bundle_name));

        if (ret == null)
        {
            Debug.LogError($"Failed to load {bundle_name}");
        }
        else
        {
            loadedBundles.Add(bundle_name, ret);
        }

        return ret;

    }

    public T GetAsset<T>(string bundle_name, string asset) where T : Object
    {
        T ret = null;

        AssetBundle bundle = LoadBundle(bundle_name);

        if (bundle != null)
        {
            ret = bundle.LoadAsset<T>(asset);
        }

        return ret;

    }

}
