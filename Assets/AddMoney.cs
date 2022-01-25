using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddMoney : MonoBehaviour
{
    public void GiveMoney()
    {
        Debug.Log("Adding 100 money");
        GlobalValues.moneyTxtValue += 100;
        SaveManager.instance.Save();
    }
}
