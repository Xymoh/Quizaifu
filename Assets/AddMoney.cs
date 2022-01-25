using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddMoney : MonoBehaviour
{

    MenuManager menuManager;


    void Awake()
    {
        menuManager = FindObjectOfType<MenuManager>();
    }


    
    public void GiveMoney()
    {
        Debug.Log("Adding 100 money");
        GlobalValues.moneyTxtValue += 100;
        menuManager.InitiateValues();
        SaveManager.instance.Save();
    }
}
