using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    [SerializeField] Text timeField;
    [SerializeField] Text wordToFindField;
    public Text WordToFindField
    {
        get { return wordToFindField; } 
        set { wordToFindField = value; } 
    }
    [SerializeField] GameObject[] healthIcons;
    public GameObject[] HealthIcons
    {
        get { return healthIcons; }
        set { healthIcons = value; }
    }

    float time;
    string[] wordsLocal = { "MATT", "JOANNE", "ROBERT", "MARRY JANE" };
    string chosenWord;
    public string ChosenWord 
    { 
        get { return chosenWord; }
        set { chosenWord = value; } 
    }
    string hiddenWord;
    public string HiddenWord 
    { 
        get { return hiddenWord; } 
        set { hiddenWord = value; }
    }
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
        charDropping = FindObjectOfType<CharDropping>();
        chosenWord = wordsLocal[Random.Range(0, wordsLocal.Length)];
    }

    void ElapseTime()
    {
        time += Time.deltaTime;
        timeField.text = time.ToString();
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
}
