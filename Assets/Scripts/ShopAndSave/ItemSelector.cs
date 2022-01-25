using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSelector : MonoBehaviour
{


    private int[] furniture = new int[4];
    [SerializeField] private GameObject[] selectedIcons;
    [SerializeField] private GameObject[] buyIcons;
    [SerializeField]  private int currentChair;

    private int previousChair; 
    // Start is called before the first frame update
    void Awake()
    {
        //code for chairs
        currentChair = SaveManager.instance.currentChair;
        changeActiveButtons(currentChair);
        checkUnlockedChairs();
    }


    void checkUnlockedChairs()
    {
        for (int i = 0; i < 4; i++)
        {
            if (SaveManager.instance.chairsUnlocked[i])
            {
                buyIcons[i].SetActive(false);
            }
            else
            {
                buyIcons[i].SetActive(true);
            }
        }
        SaveManager.instance.Save();
    }

    void changeActiveButtons(int _previousChair)
    {

        
        selectedIcons[_previousChair].SetActive(false);
        selectedIcons[currentChair].SetActive(true);
        SaveManager.instance.Save();
    }
    public void SelectButton1()
    {
        if (SaveManager.instance.chairsUnlocked[0])
        {
            previousChair = currentChair;
            currentChair = 0;
            SaveManager.instance.currentChair = currentChair;
            //SaveManager.instance.Save();
            changeActiveButtons(previousChair);
        }
        else
        {
            if(GlobalValues.moneyTxtValue>=50)
            {
             GlobalValues.moneyTxtValue -= 50;
             SaveManager.instance.chairsUnlocked[0] = true;
             //SaveManager.instance.Save();
             checkUnlockedChairs();
            }
        }
        
    }

    public void SelectButton2()
    {
        if (SaveManager.instance.chairsUnlocked[1])
        {
            previousChair = currentChair;
            currentChair = 1;
            SaveManager.instance.currentChair = currentChair;
            //SaveManager.instance.Save();
            changeActiveButtons(previousChair);
        }
        else
        {
            if (GlobalValues.moneyTxtValue >= 50)
            {
                GlobalValues.moneyTxtValue -= 50;
                SaveManager.instance.chairsUnlocked[1] = true;
                //SaveManager.instance.Save();
                checkUnlockedChairs();
            }
        }
    }

    public void SelectButton3()
    {
        if (SaveManager.instance.chairsUnlocked[2])
        {
            previousChair = currentChair;
            currentChair = 2;
            SaveManager.instance.currentChair = currentChair;
            //SaveManager.instance.Save();
            changeActiveButtons(previousChair);
        }
        else
        {
            if (GlobalValues.moneyTxtValue >= 50)
            {
                GlobalValues.moneyTxtValue -= 50;
                SaveManager.instance.chairsUnlocked[2] = true;
                //SaveManager.instance.Save();
                checkUnlockedChairs();
            }
        }
    }
    public void SelectButton4()
        {
        if (SaveManager.instance.chairsUnlocked[3])
        {
            previousChair = currentChair;
            currentChair = 3;
            SaveManager.instance.currentChair = currentChair;
            //SaveManager.instance.Save();
            changeActiveButtons(previousChair);
        }
        else
        {
            if (GlobalValues.moneyTxtValue >= 50)
            {
                GlobalValues.moneyTxtValue -= 50;
                SaveManager.instance.chairsUnlocked[3] = true;
                //SaveManager.instance.Save();
                checkUnlockedChairs();
            }
        }
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
