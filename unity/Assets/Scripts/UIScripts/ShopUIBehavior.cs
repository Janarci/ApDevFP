using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopUIBehavior : MonoBehaviour
{
    [SerializeField] private GameObject MainShop;
    [SerializeField] private GameObject CostingShop;
    [SerializeField] private GameObject EncounteredShop;

    [SerializeField] private Text Cost;
    [SerializeField] private Text Owned;
    [SerializeField] private Text BuyingAmount;
    //private int amount = 0;
    [SerializeField] private Slider slider;

    [SerializeField] private GameObject DragonHam;
    [SerializeField] private GameObject FairyFungus;
    [SerializeField] private GameObject ManaPotion;
    [SerializeField] private GameObject Carrot;
    [SerializeField] private GameObject Bomb;

    [SerializeField] private GameObject shopCollider;
    [SerializeField] private PathingScript Player;

    [SerializeField] private BombHandler bombHandler;
    [SerializeField] private HealthHandler healthHandler;
    [SerializeField] private SpellHandler spellHandler;
    [SerializeField] private CoinHandler coinHandler;

    public struct ShopItem
    {
        public int initCost;
        public int buyCount;
        public int currentCost;
    }

    ShopItem i_dragonHam;
    ShopItem i_fungus;
    ShopItem i_manaPot;
    ShopItem i_carrot;
    ShopItem i_bomb;

    // Start is called before the first frame update
    void Start()
    {
        i_dragonHam.initCost = 100;
        i_fungus.initCost = 80;
        i_manaPot.initCost = 80;
        i_carrot.initCost = 120;
        i_bomb.initCost = 350;

        i_dragonHam.buyCount = 0;
        i_fungus.buyCount = 0;
        i_manaPot.buyCount = 0;
        i_carrot.buyCount = 0;
        i_bomb.buyCount = 0;

        i_dragonHam.currentCost = i_dragonHam.initCost;
        i_fungus.currentCost = i_fungus.initCost;
        i_manaPot.currentCost = i_manaPot.initCost;
        i_carrot.currentCost = i_carrot.initCost;
        i_bomb.currentCost = i_bomb.initCost;

        resetUIPopUps();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void resetUIPopUps()
    {
        EncounteredShop.SetActive(false);
        MainShop.SetActive(false);
        CostingShop.SetActive(false);
    }

    private void resetItemChosen()
    {
        DragonHam.SetActive(false);
        FairyFungus.SetActive(false);
        ManaPotion.SetActive(false);
        Carrot.SetActive(false);
        Bomb.SetActive(false);
    }

    public void ContinueClicked()
    {
        resetUIPopUps();
        EncounteredShop.SetActive(false);
        Destroy(shopCollider);
        Player.playerStop = false;
    }

    public void ExitShopClicked()
    {
        resetUIPopUps();
        EncounteredShop.SetActive(true);
    }

    public void EnterShopClicked()
    {
        Debug.Log("Clicked");
        resetUIPopUps();
        MainShop.SetActive(true);
    }

    public void onSliderAmountChange()
    {
        BuyingAmount.text = $"{slider.value}";
    }

    public void BuyClicked()
    {
        
        if (DragonHam.activeInHierarchy)
        {
            if (slider.value != 0)
            {
                for (int i = 0; i < slider.value; i++) 
                {
                    coinHandler.setGoldTotal(coinHandler.getGoldTotal() - i_dragonHam.currentCost);
                    healthHandler.increaseMaxHealth();
                    i_dragonHam.buyCount++;
                    i_dragonHam.currentCost *= 2;
                }
            }
        }
        else if (FairyFungus.activeInHierarchy)
        {
            if (slider.value != 0)
            {
                for (int i = 0; i < slider.value; i++)
                {
                    coinHandler.setGoldTotal(coinHandler.getGoldTotal() - i_fungus.currentCost);
                    spellHandler.increaseMaxMana();
                    i_fungus.buyCount++;
                    i_fungus.currentCost -= 40;
                    i_fungus.currentCost *= 2;
                }
            }
        }
        else if (ManaPotion.activeInHierarchy)
        {
            if (slider.value != 0)
            {
                for (int i = 0; i < slider.value; i++)
                {
                    coinHandler.setGoldTotal(coinHandler.getGoldTotal() - i_manaPot.currentCost);
                    spellHandler.addManaPotion();
                    i_manaPot.buyCount++;
                    i_manaPot.currentCost = i_manaPot.initCost;
                }
            }
        }
        else if (Carrot.activeInHierarchy)
        {
            if (slider.value != 0)
            {
                for (int i = 0; i < slider.value; i++)
                {
                    coinHandler.setGoldTotal(coinHandler.getGoldTotal() - i_carrot.currentCost);
                    spellHandler.increaseManaRegen();

                    i_carrot.buyCount++;
                    i_carrot.currentCost += (50 * i_carrot.buyCount);
                }
            }
        }
        else if (Bomb.activeInHierarchy)
        {
            if (slider.value != 0)
            {
                coinHandler.setGoldTotal(coinHandler.getGoldTotal() - i_bomb.currentCost);
                bombHandler.bombAvailable = true;
                bombHandler.onBombPurchase();
                i_bomb.buyCount++;
            }
        }
        resetUIPopUps();
        MainShop.SetActive(true);
    }

    public void DragonHamClicked()
    {
        resetUIPopUps();
        resetItemChosen();
        CostingShop.SetActive(true);
        DragonHam.SetActive(true);

        Cost.text = $"Cost: {i_dragonHam.currentCost} Gold";
        Owned.text = $"Consumed: {i_dragonHam.buyCount}";

        int tempGoldTotal = coinHandler.getGoldTotal();
        int tempCurrentCost = i_dragonHam.currentCost;
        slider.maxValue = 0;
        while (tempGoldTotal >= tempCurrentCost)
        {
            tempGoldTotal -= tempCurrentCost;
            tempCurrentCost *= 2;
            slider.maxValue++;
        }
        slider.minValue = 0;
        
    }

    public void FungusClicked()
    {
        resetUIPopUps();
        resetItemChosen();
        CostingShop.SetActive(true);
        FairyFungus.SetActive(true);

        Cost.text = $"Cost: {i_fungus.currentCost} Gold";
        Owned.text = $"Consumed: {i_fungus.buyCount}";

        int tempGoldTotal = coinHandler.getGoldTotal();
        int tempCurrentCost = i_fungus.currentCost;
        slider.maxValue = 0;
        while (tempGoldTotal >= tempCurrentCost)
        {
            tempGoldTotal -= tempCurrentCost;
            tempCurrentCost -= 40;
            tempCurrentCost *= 2;
            slider.maxValue++;
        }
        slider.minValue = 0;
    }

    public void ManaPotClicked()
    {
        resetUIPopUps();
        resetItemChosen();
        CostingShop.SetActive(true);
        ManaPotion.SetActive(true);

        Cost.text = $"Cost: {i_manaPot.currentCost} Gold";
        Owned.text = $"Owned: {spellHandler.manaPotionAmount}";

        slider.maxValue = (coinHandler.getGoldTotal() / i_manaPot.currentCost);
        slider.minValue = 0;
    }

    public void CarrotClicked()
    {
        resetUIPopUps();
        resetItemChosen();
        CostingShop.SetActive(true);
        Carrot.SetActive(true);

        Cost.text = $"Cost: {i_carrot.currentCost} Gold";
        Owned.text = $"Consumed: {i_carrot.buyCount}";

        int tempGoldTotal = coinHandler.getGoldTotal();
        int tempCurrentCost = i_carrot.currentCost;
        int tempBuyCount = i_carrot.buyCount;
        slider.maxValue = 0;
        while (tempGoldTotal >= tempCurrentCost)
        {
            tempGoldTotal -= tempCurrentCost;
            tempBuyCount++;
            slider.maxValue++;
            tempCurrentCost += (50 * tempBuyCount);
            
        }
        slider.minValue = 0;
    }

    public void BombClicked()
    {
        resetUIPopUps();
        resetItemChosen();
        CostingShop.SetActive(true);
        Bomb.SetActive(true);

        Cost.text = $"Cost: {i_bomb.currentCost} Gold";
        

        if (!bombHandler.bombAvailable){
            Owned.text = $"Owned: 0\n You can only have 1 bomb at a time!";
            slider.maxValue = (coinHandler.getGoldTotal()/ i_bomb.currentCost);
            if (slider.maxValue > 1)
            {
                slider.maxValue = 1;
            }
        }
        else{
            Owned.text = $"Owned: 1\n You can only have 1 bomb at a time!";
            slider.maxValue = 0;
        }

        slider.minValue = 0;
    }


}
