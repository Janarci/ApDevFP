using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapDestroy : MonoBehaviour
{
    [SerializeField] private int fairyType;
    //[SerializeField] private GameObject SpellManager;
    [SerializeField] private SpellHandler Spellhandler;
    [SerializeField] private CoinHandler coin;
    public sfxHandler sfx;

    bool killed = false;
    private int currentSpell = 0;
    public void destroyObj()
    {
        currentSpell = Spellhandler.currentSpell();
        if (Spellhandler.getCurrentMana() >= 20)
        {
            sfx.play();
            Spellhandler.SpellUse();
            if (currentSpell == fairyType && !killed)
            {
                killed = true;
                coin.getCoin();
                fairyAnim animation = this.gameObject.GetComponent<fairyAnim>();
                animation.animDead();
                Destroy(this.gameObject, 2.5f);
            }
        }
    }
}
