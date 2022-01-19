using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PersistentManager : MonoBehaviour
{
    public static PersistentManager Instance { get; private set; }

    int _healthSliderValue = 100;
    public int HealthSliderValue 
    {
        get => _healthSliderValue;
        set => _healthSliderValue = value;
    }

    int _energySliderValue = 100;
    public int EnergySliderValue 
    {
        get => _energySliderValue;
        set => _energySliderValue = value;
    }

    int _foodSliderValue = 100;
    public int FoodSliderValue 
    { 
        get => _foodSliderValue; 
        set => _foodSliderValue = value; 
    }

    int _funSliderValue = 100;
    public int FunSliderValue 
    {
        get => _funSliderValue;
        set => _funSliderValue = value;
    }

    int _moneyTxtValue = 250;
    public int MoneyTxtValue
    {
        get => _moneyTxtValue;
        set => _moneyTxtValue = value;
    }

    int _levelTxtValue = 1;
    public int LevelTXtValue 
    {
        get => _levelTxtValue;
        set => _levelTxtValue = value;
    }

    void Awake()
    {
        if (Instance == null) 
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }    
    }
}
