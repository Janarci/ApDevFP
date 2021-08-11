using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapDestroy : MonoBehaviour
{
    [SerializeField] private int fairyType;
    //[SerializeField] private GameObject SpellManager;
    [SerializeField] private SpellHandler Spellhandler;
    [SerializeField] private CoinHandler coin;
    bool killed = false;

    private int currentSpell = 0;
	private void Awake()
	{
        //Spellhandler = SpellManager.GetComponent<SpellHandler>();
	}
	IEnumerator destroyDelay()
    {
        yield return new WaitForSeconds(2.5f);
        
    }

    public void destroyObj()
    {
        currentSpell = Spellhandler.currentSpell();
        Spellhandler.SpellUse();
        if (currentSpell == fairyType && !killed)
        {
            killed = true;
            coin.getCoin();
            fairyAnim animation = this.gameObject.GetComponent<fairyAnim>();
            animation.animDead();
            Destroy(this.gameObject, 2.5f);
            //StartCoroutine(destroyDelay());
        }
    }
}
