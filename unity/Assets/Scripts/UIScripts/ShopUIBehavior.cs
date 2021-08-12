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

        i_dragonHam.initCost = i_dragonHam.currentCost;
        i_fungus.initCost = i_fungus.currentCost;
        i_manaPot.initCost = i_manaPot.currentCost;
        i_carrot.initCost = i_carrot.currentCost;
        i_bomb.initCost = i_bomb.currentCost;

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
        resetUIPopUps();
        if (DragonHam.activeInHierarchy)
        {
            if (slider.value != 0)
            {
                for (int i = 0; i < slider.value; i++) {
                    //minus gold
                    //add item by amount bought
                    //^^^^first
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
                    //minus gold
                    //add item by amount bought
                    //^^^^first
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
                    //minus gold
                    //add item by amount bought
                    //^^^^first
                    i_manaPot.buyCount++;
                }
            }
        }
        else if (Carrot.activeInHierarchy)
        {
            if (slider.value != 0)
            {
                for (int i = 0; i < slider.value; i++)
                {
                    //minus gold
                    //add item by amount bought
                    //^^^^first
                    i_carrot.buyCount++;
                    i_carrot.currentCost += (50 * i_carrot.buyCount);
                }
            }
        }
        else if (Bomb.activeInHierarchy)
        {
            if (slider.value != 0)
            {
                //minus gold
                //add item by amount bought
                //^^^^first
                i_bomb.buyCount++;
            }
        }
        //minus gold
        //add item by amount bought
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

        //slider.maxValue = goldAmount / i_dragonHam.currentCost;
        //slider.minValue = 0;

        //change text of cost
        //change sliderMinMax
        //change text of Owned

    }

    public void FungusClicked()
    {
        resetUIPopUps();
        resetItemChosen();
        CostingShop.SetActive(true);
        FairyFungus.SetActive(true);

        Cost.text = $"Cost: {i_fungus.currentCost} Gold";
        Owned.text = $"Consumed: {i_fungus.buyCount}";

        //slider.maxValue = goldAmount / i_dragonHam.currentCost;
        //slider.minValue = 0;
    }

    public void ManaPotClicked()
    {
        resetUIPopUps();
        resetItemChosen();
        CostingShop.SetActive(true);
        ManaPotion.SetActive(true);

        Cost.text = $"Cost: {i_manaPot.currentCost} Gold";
        //Owned.text = $"Owned: {inventory_amount}";

        //slider.maxValue = goldAmount / i_dragonHam.currentCost;
        //slider.minValue = 0;
    }

    public void CarrotClicked()
    {
        resetUIPopUps();
        resetItemChosen();
        CostingShop.SetActive(true);
        Carrot.SetActive(true);

        Cost.text = $"Cost: {i_carrot.currentCost} Gold";
        Owned.text = $"Consumed: {i_carrot.buyCount}";

        //slider.maxValue = goldAmount / i_dragonHam.currentCost;
        //slider.minValue = 0;
    }

    public void BombClicked()
    {
        resetUIPopUps();
        resetItemChosen();
        CostingShop.SetActive(true);
        Bomb.SetActive(true);

        Cost.text = $"Cost: {i_bomb.currentCost} Gold";
        //Owned.text = $"Owned: {inventory_amount}\n You can only have 1 bomb at a time!";
        //if (inventory_amount == 0){
        //slider.maxValue = goldAmount / i_dragonHam.currentCost;
        //}
        //else{
        //slider.maxValue = 0;
        //}
        //slider.minValue = 0;
    }


}
