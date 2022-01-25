using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetValues : MonoBehaviour
{
    // Start is called before the first frame update
    public void ResettingValues()
    {

        for (int i = 0; i < SaveManager.instance.chairsUnlocked.Length; i++)
        {
            SaveManager.instance.chairsUnlocked[i] = false;
        }
        SaveManager.instance.chairsUnlocked[0] = true;
        SaveManager.instance.currentChair = 0;

        GlobalValues.moneyTxtValue = 0;
        SaveManager.instance.Save();
        Debug.Log("Resetting values to default...");

    }
}
