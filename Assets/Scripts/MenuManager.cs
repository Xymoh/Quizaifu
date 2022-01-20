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
        healthSlider.value = PersistentManager.healthSliderValue;
        energySlider.value = PersistentManager.energySliderValue;
        foodSlider.value = PersistentManager.foodSliderValue;
        funSlider.value = PersistentManager.funSliderValue;

        // Setting money and lvl in txt
        moneyTxt.text = PersistentManager.moneyTxtValue.ToString();
        levelTxt.text = PersistentManager.levelTxtValue.ToString();
    }

    public void LoadGame()
    {
        if (PersistentManager.energySliderValue >= 15)
        {
            Time.timeScale = 1;
            PersistentManager.energySliderValue -= 15;

            if (PersistentManager.energySliderValue < 0)
            {
                PersistentManager.energySliderValue = 0;
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
