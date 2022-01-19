using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    CharDropping charDropping;

    [SerializeField] Text timeField;
    [SerializeField] string[] wordsLocal;
    float time;
    
    [HideInInspector] public Text wordToFindField;
    [HideInInspector] public string hiddenWord;
    [HideInInspector] public string chosenWord;
    [HideInInspector] public int fails;
    public GameObject[] healthIcons;
    public Slider foodSlider;
    public GameObject wonGame;
    public GameObject lostGame;
    
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
        foodSlider.value = PersistentManager.foodSliderValue;
        charDropping = FindObjectOfType<CharDropping>();
        chosenWord = wordsLocal[Random.Range(0, wordsLocal.Length)];
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
        Time.timeScale = 1;
        SceneManager.LoadScene("Menu");
    }
}
