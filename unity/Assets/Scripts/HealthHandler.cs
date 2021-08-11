using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DamageHandler : MonoBehaviour
{

    private float healthMax = 100;
    private float currentHealth = 0;
    private float fairyDamage = 20;
    [SerializeField] private HealthScript health;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = healthMax;
        health.setHealthMax(healthMax);

        
    }

    // Update is called once per frame
    void Update()
    {
        health.updateHealth(currentHealth);
        
    }

    public void getHit()
    {
        currentHealth -= 20;
        health.updateHealth(currentHealth);
    }
}
