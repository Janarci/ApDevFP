using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakeScript : MonoBehaviour
{


    public float ShakeDetectionThreshold;
    public float MinShakeInterval;

    private float sqrShakeDetectionThreshold;

    private float timeSinceLastShake;


    private SpawnManager spawnM;

    // Start is called before the first frame update
    void Start()
    {
        sqrShakeDetectionThreshold = Mathf.Pow(ShakeDetectionThreshold, 2);
        spawnM = GetComponent<SpawnManager>();


        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.acceleration.sqrMagnitude >= sqrShakeDetectionThreshold)
        {
            spawnM.destroyAllFairy();
        }
        
    }


}
