using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopMenu : MonoBehaviour
{
    [SerializeField] int foodHealth;
    [SerializeField] int foodEnergy;
    [SerializeField] int foodFood;
    [SerializeField] int foodMoney;

    MenuManager menuManager;

    void Awake() 
    {
        menuManager = FindObjectOfType<MenuManager>();
    }

    public void BuyFood()
    {
        if (GlobalValues.moneyTxtValue > foodMoney)
        {
            GlobalValues.healthSliderValue += foodHealth;
            GlobalValues.energySliderValue += foodEnergy;
            GlobalValues.foodSliderValue += foodFood;
            GlobalValues.moneyTxtValue -= foodMoney;

            if (GlobalValues.healthSliderValue > 100)
            {
                GlobalValues.healthSliderValue = 100;
            }
            if (GlobalValues.energySliderValue > 100)
            {
                GlobalValues.energySliderValue = 100;
            }
            if (GlobalValues.foodSliderValue > 100)
            {
                GlobalValues.foodSliderValue = 100;
            }
            if (GlobalValues.moneyTxtValue < 0)
            {
                GlobalValues.moneyTxtValue = 0;
            }
        }

        menuManager.InitiateValues();
    }
}
