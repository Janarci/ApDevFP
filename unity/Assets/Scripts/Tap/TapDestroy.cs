using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapDestroy : MonoBehaviour
{
    [SerializeField] private int fairyType;
    [SerializeField] private int dragonType;
    [SerializeField] private bool shield;
    //[SerializeField] private GameObject SpellManager;
    [SerializeField] private SpellHandler Spellhandler;
    [SerializeField] private CoinHandler coin;
    public sfxHandler sfx;

    bool killed = false;
    private int currentSpell;
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
                fairyAnim animation = this.gameObject.GetComponent<fairyAnim>();
                animation.animDead();
                Destroy(this.gameObject, 2.5f);
            }

            else if (currentSpell == dragonType) {

                killed = true;
                coin.getCoin();
                Transform dragon = this.gameObject.transform.root;
                Destroy(dragon.gameObject, 2.5f);
                DragonPathfind animation = dragon.GetComponent<DragonPathfind>();
                animation.animDead();
            }
            else if (shield == true) {
                Destroy(this.gameObject);
            }
        }
    }
}
