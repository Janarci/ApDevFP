using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakeScript : MonoBehaviour
{


    public float ShakeDetectionThreshold;
    public float MinShakeInterval;

    private float sqrShakeDetectionThreshold;

    private float timeSinceLastShake;
    private BombHandler bomb;


    private SpawnManager spawnM;

    // Start is called before the first frame update
    void Start()
    {
        bomb = GameObject.Find("BombManager").GetComponent<BombHandler>();
        sqrShakeDetectionThreshold = Mathf.Pow(ShakeDetectionThreshold, 2);
        spawnM = GetComponent<SpawnManager>();


        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.acceleration.sqrMagnitude >= sqrShakeDetectionThreshold && bomb.bombAvailable)
        {
            bomb.onBombUse();
            spawnM.destroyAllFairy();
        }
        
    }


}
