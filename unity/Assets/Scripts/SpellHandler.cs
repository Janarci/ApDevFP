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

    public ManaScript mana;

	void Start()
    {
        currentMana = manaMax;
        mana.setManaMax(manaMax);
        
    }
	private void Update()
	{
        if(currentMana < manaMax)
            currentMana += 5.0f * Time.deltaTime;
        mana.updateMana(currentMana);
	}


	// Update is called once per frame
	public void fireSpell()
    {
        spellType = 1;

    }
    public void elecSpell()
    {
        spellType = 2;
    }
    public void waterSpell()
    {
        spellType = 3;
    }


    public int currentSpell()
    {
        return spellType;
    }

    public void SpellUse()
    {
        currentMana -= 20;
        mana.updateMana(currentMana);
    }
}
