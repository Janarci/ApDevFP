using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheatScript : MonoBehaviour
{

    private bool infMana;
    private bool infHealth;
    private bool infMoney;

	private void Awake()
	{
        DontDestroyOnLoad(this);
		
	}

	public void infManaOn(bool value)
    {
        if (value)
        {

            infMana = true;
        }
        else
        {
            infMana = false;
        }
    }
    public void infHealthOn(bool value)
    {
        if (value)
            infHealth = true;
        else
        {
            Debug.Log("works");

            infHealth = false;
        }
    }
    public void infMoneyOn(bool value)
    {
        if (value)
            infMoney = true;
        else
            infMoney = false;

    }

    public bool manaCheat()
    {
        return infMana;
    }

    public bool healthCheat()
    {
        return infHealth;
    }

    public bool moneyCheat()
    {
        return infMoney;
    }

}
