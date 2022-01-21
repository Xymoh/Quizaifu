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

    void Awake()
    {
        InitiateValues();
    }

    public void InitiateValues()
    {
        // Setting Sliders
        healthSlider.value = GlobalValues.healthSliderValue;
        energySlider.value = GlobalValues.energySliderValue;
        foodSlider.value = GlobalValues.foodSliderValue;
        funSlider.value = GlobalValues.funSliderValue;

        // Setting money and lvl in txt
        moneyTxt.text = GlobalValues.moneyTxtValue.ToString();
        levelTxt.text = GlobalValues.levelTxtValue.ToString();
    }

    public void LoadGame()
    {
        if (GlobalValues.energySliderValue >= 15)
        {
            Time.timeScale = 1;
            GlobalValues.energySliderValue -= 15;

            if (GlobalValues.energySliderValue < 0)
            {
                GlobalValues.energySliderValue = 0;
            }

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

    public void LoadHome()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("House");
    }
}
