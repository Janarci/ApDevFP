using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapDestroy : MonoBehaviour
{
    [SerializeField] private int fairyType;
    [SerializeField] private int dragonType;
    [SerializeField] private bool shield;
    //[SerializeField] private GameObject SpellManager;
    private SpellHandler Spellhandler;
    private CoinHandler coin;
    private sfxHandler sfx;

    bool killed = false;
    private int currentSpell;

	private void Awake()
	{
        sfx = GameObject.Find("SpellAudioSource").GetComponent<sfxHandler>();
        Spellhandler = GameObject.Find("SpellManager").GetComponent<SpellHandler>();
        coin = GameObject.Find("CoinManager").GetComponent<CoinHandler>();

        if (shield)
        {
            this.gameObject.GetComponentInChildren<Renderer>().material = Resources.Load<Material>("Glass 3"); ;

        }

    }
    public void destroyObj()
    {
        currentSpell = Spellhandler.currentSpell();
        if (Spellhandler.getCurrentMana() >= 20 && !killed)
        {
            sfx.play();
            Spellhandler.SpellUse();
            if (currentSpell == fairyType)
            {
                killed = true;
                coin.getCoin();
                coin.getScoreFairy();
                fairyAnim animation = this.gameObject.GetComponent<fairyAnim>();
                animation.animDead();
                Destroy(this.gameObject, 2.5f);
            }

            else if (currentSpell == dragonType) {

                killed = true;
                coin.getCoin();
                coin.getScoreBoss();
                Transform dragon = this.gameObject.transform.root;
                DragonPathfind animation = dragon.gameObject.GetComponent<DragonPathfind>();
                animation.animDead();
                Destroy(dragon.gameObject, 2.5f);
            }
        }
    }

    public void destroyObjShield()
    {
        if (Spellhandler.getCurrentMana() >= 30 && shield)
        {
            sfx.play();
            Spellhandler.SpellUse();
             Destroy(this.gameObject);
            
        }
    }
}
