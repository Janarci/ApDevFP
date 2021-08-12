using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathColliderScript : MonoBehaviour
{
    public Collider Player;
    public bool pathComplete = false;
    public PathingScript pathingManager;

    private bool triggerOnce = false;

    public void OnTriggerEnter(Collider other)
    {
        if (other == Player)
        {
            if (!triggerOnce)
            {
                pathComplete = true;
                Debug.Log("PathComplete1");
                pathingManager.currentLocation += 1;
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
        
    }
}
