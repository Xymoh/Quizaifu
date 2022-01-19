using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [Header("Value Sliders")]
    [SerializeField] Slider healthSlider;
    [SerializeField] Slider energySlider;
    [SerializeField] Slider foodSlider;
    [SerializeField] Slider funSlider;

    [Header("Text Values")]
    [SerializeField] Text moneyTxt;
    [SerializeField] Text levelTxt;

    PersistentManager persistentManager;

    void Awake()
    {
        InitiateValues();
    }

    void InitiateValues()
    {
        // Setting Sliders
        healthSlider.value = PersistentManager.Instance.HealthSliderValue;
        energySlider.value = PersistentManager.Instance.EnergySliderValue;
        foodSlider.value = PersistentManager.Instance.FoodSliderValue;
        funSlider.value = PersistentManager.Instance.FunSliderValue;

        // Setting money and lvl in txt
        moneyTxt.text = PersistentManager.Instance.MoneyTxtValue.ToString();
        levelTxt.text = PersistentManager.Instance.LevelTXtValue.ToString();
    }

    public void LoadGame()
    {
        if (PersistentManager.Instance.EnergySliderValue >= 15)
        {
            Time.timeScale = 1;
            PersistentManager.Instance.EnergySliderValue -= 15;
            SceneManager.LoadScene("WordCatchGame");
        }
    }

    public void LoadShop()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Shop");
    }

    public void LoadMain()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Menu");
    }
}
