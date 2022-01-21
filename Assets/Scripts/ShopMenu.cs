using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopMenu : MonoBehaviour
{
    [SerializeField] int foodHealth;
    [SerializeField] int foodEnergy;
    [SerializeField] int foodFood;
    [SerializeField] int foodMoney;

    public void BuyFood()
    {
        if (PersistentManager.moneyTxtValue > foodMoney)
        {
            PersistentManager.healthSliderValue += foodHealth;
            PersistentManager.energySliderValue += foodEnergy;
            PersistentManager.foodSliderValue += foodFood;
            PersistentManager.moneyTxtValue -= foodMoney;

            if (PersistentManager.healthSliderValue > 100)
            {
                PersistentManager.healthSliderValue = 100;
            }
            if (PersistentManager.energySliderValue > 100)
            {
                PersistentManager.energySliderValue = 100;
            }
            if (PersistentManager.foodSliderValue > 100)
            {
                PersistentManager.foodSliderValue = 100;
            }
            if (PersistentManager.moneyTxtValue < 0)
            {
                PersistentManager.moneyTxtValue = 0;
            }
        }
    }
}
