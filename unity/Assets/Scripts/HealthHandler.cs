using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthHandler : MonoBehaviour
{

    private float healthMax = 100;
    private float currentHealth = 0;
    private float fairyDamage = 20;
    private float bossDamage = 50;
    [SerializeField] private HealthScript health;
    private CheatScript cheats;

    // Start is called before the first frame update
    void Start()
    {
        cheats = GameObject.Find("CheatsManager").GetComponent<CheatScript>();
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
        if (!cheats.healthCheat())
        {
            currentHealth -= fairyDamage;
            health.updateHealth(currentHealth);
        }
    }

    public void getHitBoss()
    {
        if (!cheats.healthCheat())
        {
            currentHealth -= bossDamage;
            health.updateHealth(currentHealth);
        }
    }

    public void increaseMaxHealth()
    {
        healthMax += 80;
    }

    public void fullHeal()
    {
        currentHealth = healthMax;
    }
}
