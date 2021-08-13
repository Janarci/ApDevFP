using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SpellHandler : MonoBehaviour
{
    // Start is called before the first frame update

    private int spellType = 1;
	private float manaMax = 100;
    private float currentMana = 0;
    private float spellcost = 20;
    private float manaRegen = 5.0f;
    public float manaPotionAmount = 0;
    /*[Range(0f, 10f)]
    [Space]
    [Header("TestText")]
    [Tooltip("hover tooltip")]*/
    public Text ManaPotionDisplay;
    public ManaScript mana;
    public sfxHandler sfx;
    private CheatScript cheats;
    void Start()
    {
        cheats = GameObject.Find("CheatsManager").GetComponent<CheatScript>();
        currentMana = manaMax;
        mana.setManaMax(manaMax);
        sfx.setCurrentSound("Fire");
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

    public void useManaPotion()
    {
        if (manaPotionAmount > 0)
        {
            currentMana = manaMax;
            manaPotionAmount--;
            ManaPotionDisplay.text = $"{manaPotionAmount}";
            //gulpsound i suppose
            //sfx.setCurrentSound("Water");
        }
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
        manaMax += 60;
        mana.setManaMax(manaMax);
    }

    public void increaseManaRegen()
    {
        manaRegen += 1.2f;
    }

    public void addManaPotion()
    {
        manaPotionAmount += 1;
        ManaPotionDisplay.text = $"{manaPotionAmount}";
    }

    public void lowerSpellCost()
    {
        //for future spell cost increase through shop

    }
}
