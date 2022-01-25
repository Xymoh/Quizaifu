using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    [Header("Text Fields")]
    [SerializeField] Text timeField;
    [SerializeField] Text tipField;
    [Header("Words to guess and tips")]
    [SerializeField] string[] wordsLocal;
    [SerializeField] string[] wordTip;
    
    float time;
    int index;
    
    [HideInInspector] public Text wordToFindField;
    [HideInInspector] public string hiddenWord;
    [HideInInspector] public string chosenWord;
    [HideInInspector] public int fails;
    public GameObject[] healthIcons;
    [Space(10)]
    public Slider foodSlider;
    [Header("End game Panels")]
    public GameObject wonGame;
    public GameObject lostGame;

    CharDropping charDropping;
    
    void Awake()
    {
        InitiateGame();
        HideWord();
    }

    void Update()
    {
        ElapseTime();
    }

    void InitiateGame()
    {
        TimeScale(0);
        foodSlider.value = GlobalValues.foodSliderValue;
        charDropping = FindObjectOfType<CharDropping>();

        index = Random.Range(0, wordsLocal.Length);
        chosenWord = wordsLocal[index];
        tipField.text = wordTip[index];
    }

    void ElapseTime()
    {
        time += Time.deltaTime;
        timeField.text = time.ToString("N0");
    }

    void HideWord()
    {
        for (int i = 0; i < chosenWord.Length; i++)
        {
            char letter = chosenWord[i];

            if (char.IsWhiteSpace(letter))
            {
                hiddenWord += " ";
            }
            else
            {
                hiddenWord += "*";
            }
        }

        wordToFindField.text = hiddenWord;
    }

    public void ReturnToMenu()
    {
        TimeScale(1f);
        SceneManager.LoadScene("Menu");
    }

    public void ReturnToShop()
    {
        TimeScale(1f);
        SceneManager.LoadScene("Shop");
    }

    public void TimeScale(float scale)
    {
        Time.timeScale = scale; 
    }
}
