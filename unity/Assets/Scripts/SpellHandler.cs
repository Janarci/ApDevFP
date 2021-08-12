using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SpellHandler : MonoBehaviour
{
    // Start is called before the first frame update

    private int spellType = 0;
	private float manaMax = 100;
    private float currentMana = 0;
    private float spellcost = 20;
    private float manaRegen = 5.0f;
    /*[Range(0f, 10f)]
    [Space]
    [Header("TestText")]
    [Tooltip("hover tooltip")]*/
    public ManaScript mana;
    public sfxHandler sfx;
    private CheatScript cheats;
    void Start()
    {
        cheats = GameObject.Find("CheatsManager").GetComponent<CheatScript>();
        currentMana = manaMax;
        mana.setManaMax(manaMax);
        //bool TruorFal = (Random.value > 0.5f);
        //change editor color when game run
    }
	private void Update()
	{
        if(currentMana < manaMax)
            currentMana += manaRegen * Time.deltaTime;
        mana.updateMana(currentMana);
	}


	// Update is called once per frame
	public void fireSpell()
    {
        spellType = 1;
        sfx.setCurrentSound("Fire");
    }
    public void elecSpell()
    {
        spellType = 2;
        sfx.setCurrentSound("Electric");

    }
    public void waterSpell()
    {
        spellType = 3;
        sfx.setCurrentSound("Water");

    }


    public int currentSpell()
    {
        return spellType;
    }
    public float getCurrentMana()
    {
        return currentMana;
    }

    public void SpellUse()
    {
        if (!cheats.manaCheat())
        {
            currentMana -= spellcost;
            mana.updateMana(currentMana);
        }
    }

    public void increaseMaxMana()
    {
        //setmanamax call
        //for future max mana increase through shop
    }

    public void increaseManaRegen()
    {
        //for future mana regen increase through shop
    }

    public void lowerSpellCost()
    {
        //for future spell cost increase through shop

    }
}
