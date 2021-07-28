using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapReceiver : MonoBehaviour
{
    [SerializeField] private GameObject fairy1;
    [SerializeField] private GameObject fairy2;

    // Start is called before the first frame update
    void Start()
    {
        GestureManager.Instance.onTap += onTap;
    }

    private void OnDisable()
    {
        GestureManager.Instance.onTap -= onTap;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void onTap(object sender, TapEventArgs args)
    {
        if (args.HitObject != null)
        {
            Debug.Log("hit!");
            
        }
    }
}
